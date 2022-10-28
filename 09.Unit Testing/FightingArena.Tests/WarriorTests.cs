using NUnit.Framework;
using System;

namespace FightingArena //Tests
{
    public class WarriorTests
    {
        [Test]
        public void ConstructorShouldWorkCorrectlyForName()
        {
            string warriorName = "warriorName";
            int damage = 50;
            int hp = 60;

            Warrior warrior = new Warrior(warriorName, damage, hp);

            Assert.AreEqual(warriorName, warrior.Name);
        }
        [Test]
        public void ConstructorShouldWorkCorrectlyForDamage()
        {
            string warriorName = "warriorName";
            int damage = 50;
            int hp = 60;

            Warrior warrior = new Warrior(warriorName, damage, hp);
            
            Assert.AreEqual(damage, warrior.Damage);            
        }

        [Test]
        public void ConstructorShouldWorkCorrectlyForHP()
        {
            string warriorName = "warriorName";
            int damage = 50;
            int hp = 60;

            Warrior warrior = new Warrior(warriorName, damage, hp);

            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        public void ConstructorShouldThrowExceptionForNullName()
        {
            string warriorName = null;
            int damage = 50;
            int hp = 60;
            Assert.Throws<ArgumentException>(() => new Warrior(warriorName, damage, hp));
        }
        [Test]
        public void ConstructorShouldThrowExceptionForEmptyName()
        {
            string warriorName = string.Empty;
            int damage = 50;
            int hp = 60;
            Assert.Throws<ArgumentException>(() => new Warrior(warriorName, damage, hp));
        }
        [Test]
        public void ConstructorShouldThrowExceptionForWhiteSpaceName()
        {
            string warriorName = " ";
            int damage = 50;
            int hp = 60;
            Assert.Throws<ArgumentException>(() => new Warrior(warriorName, damage, hp));
        }

        [Test]
        public void ConstructorShouldThrowExceptionForZeroDemage()
        {
            string warriorName = "someName";
            int damage = 0;
            int hp = 60;
            Assert.Throws<ArgumentException>(() => new Warrior(warriorName, damage, hp));
        }

        [Test]
        public void ConstructorShouldThrowExceptionForNegativeDemage()
        {
            string warriorName = "someName";
            int damage = -10;
            int hp = 60;
            Assert.Throws<ArgumentException>(() => new Warrior(warriorName, damage, hp));
        }

        [Test]
        public void ConstructorShouldThrowExceptionForNegativeHP()
        {
            string warriorName = "someName";
            int damage = 50;
            int hp = -60;
            Assert.Throws<ArgumentException>(() => new Warrior(warriorName, damage, hp));
        }

        [Test]
        public void AtackShouldThrowInvalidOperationExceptionForHPLessThanMINHP()
        {
            string attackWarriorName = "someName";
            int attackDamage = 50;
            int attackHP = 20;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 10;
            int defenceHP = 40;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);

            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [Test]
        public void AtackShouldThrowInvalidOperationExceptionForHPEqualToMinHP()
        {
            string attackWarriorName = "someName";
            int attackDamage = 50;
            int attackHP = 30;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 30;
            int defenceHP = 40;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);

            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [Test]
        public void AtackShouldThrowInvalidOperationExceptionForEnemyHPLessThanMinHP()
        {
            string attackWarriorName = "someName";
            int attackDamage = 50;
            int attackHP = 40;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 40;
            int defenceHP = 20;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);

            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [Test]
        public void AtackShouldThrowInvalidOperationExceptionForEnemyHPEqualToMinHP()
        {
            string attackWarriorName = "someName";
            int attackDamage = 50;
            int attackHP = 40;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 35;
            int defenceHP = 30;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);

            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [Test]
        public void AtackShouldThrowInvalidOperationExceptionForStrongerEnemy()
        {
            string attackWarriorName = "someName";
            int attackDamage = 50;
            int attackHP = 40;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 50;
            int defenceHP = 35;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);

            Assert.Throws<InvalidOperationException>(() => attackWarrior.Attack(defenceWarrior));
        }

        [Test]
        public void AtackShouldDecreaseHpWithEnemyDemege()
        {
            string attackWarriorName = "someName";
            int attackDamage = 60;
            int attackHP = 80;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 50;
            int defenceHP = 70;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);
            
            attackWarrior.Attack(defenceWarrior);

            Assert.AreEqual(30, attackWarrior.HP);
        }

        [Test]
        public void AtackShouldDecreaseEnemyHpWithDemege()
        {
            string attackWarriorName = "someName";
            int attackDamage = 60;
            int attackHP = 80;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 50;
            int defenceHP = 70;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);

            attackWarrior.Attack(defenceWarrior);

            Assert.AreEqual(10, defenceWarrior.HP);
        }

        [Test]
        public void AtackShouldSetEnemyHpToZeroIfLessThanDamage()
        {
            string attackWarriorName = "someName";
            int attackDamage = 60;
            int attackHP = 80;

            Warrior attackWarrior = new Warrior(attackWarriorName, attackDamage, attackHP);

            string defenceWarriorName = "someOtherName";
            int defenceDamage = 50;
            int defenceHP = 50;

            Warrior defenceWarrior = new Warrior(defenceWarriorName, defenceDamage, defenceHP);

            attackWarrior.Attack(defenceWarrior);

            Assert.AreEqual(0, defenceWarrior.HP);
        }
    }
}