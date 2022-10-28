using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena //Tests
{
    public class ArenaTests
    {
        [Test]
        public void ArenaConstructorImplementCollection()
        {
            Arena arena = new Arena();
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void ArenaConstructorImplementEmptyCollection()
        {
            Arena arena = new Arena();
            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void ArenaAddWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("name", 50, 50);
            arena.Enroll(warrior);
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void ArenaContainsWarrior()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("name", 50, 50);
            arena.Enroll(warrior);
            Assert.IsTrue(arena.Warriors.Contains(warrior));
        }

        [Test]
        public void ArenaContainsWarriorsAndCountWork()
        {
            Arena arena = new Arena();
            Warrior warrior1 = new Warrior("name1", 50, 50);
            Warrior warrior2 = new Warrior("name2", 50, 50);
            Warrior warrior3 = new Warrior("name3", 50, 50);
            arena.Enroll(warrior1);
            arena.Enroll(warrior2);
            arena.Enroll(warrior3);
            Assert.IsTrue(arena.Warriors.Contains(warrior1));
            Assert.IsTrue(arena.Warriors.Contains(warrior2));
            Assert.IsTrue(arena.Warriors.Contains(warrior3));
            Assert.AreEqual(3, arena.Count);

        }

        [Test]
        public void ArenaReadOnlyCollectionCountIsEqualToCount()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("name", 50, 50);
            arena.Enroll(warrior);
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
        }

        [Test]
        public void EnrollThrowsInvalidOperationExceptionForSameName()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("name", 50, 50);
            Warrior warrior2 = new Warrior("name", 60, 60);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior2));
        }

        [Test]
        public void FightThrowsInvalidOperationExceptionForNullName()
        {
            Arena arena = new Arena();
            string attackerName = "Name";
            string defenderName = "NoName";
            Warrior warrior = new Warrior(attackerName, 50, 50);           
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }

        [Test]
        public void FightThrowsInvalidOperationExceptionForWarriorNotFound()
        {
            Arena arena = new Arena();
            string attackerName = "Name";
            string defenderName = "NoName";
            Warrior warrior = new Warrior(attackerName, 50, 50);           
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(defenderName, attackerName));
        }

        [Test]
        public void FightThrowsInvalidOperationExceptionForWarriorsNotFound()
        {
            Arena arena = new Arena();
            string attackerName = "Name";
            string defenderName = "NoName";
            Assert.Throws<InvalidOperationException>(() => arena.Fight(defenderName, attackerName));
        }

        [Test]
        public void FightWorksForValidWarriors()
        {
            Arena arena = new Arena();
            Warrior attackerWarrior = new Warrior("AttackName", 50, 50);
            Warrior defenderWarrior = new Warrior("DefendName", 50, 50);
            arena.Enroll(attackerWarrior);
            arena.Enroll(defenderWarrior);
            arena.Fight("AttackName", "DefendName");
            Assert.AreEqual(0, attackerWarrior.HP);
            Assert.AreEqual(0, defenderWarrior.HP);

        }

    }
}
