using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{//NOTE: WarController class methods are called from the Engine so these methods must NOT receive the command parameter (the first argument from the input line) as part of the arguments!a

    public class WarController
    {
        private readonly List<Character> party;
        private readonly Stack<Item> pool;
        public WarController()
        {
            party = new List<Character>();
            pool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character;
            if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
            else if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType)); //check Message???
            }
            string result = string.Format(SuccessMessages.JoinParty, name);
            party.Add(character);
            return result;

        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];


            Item item;
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            pool.Push(item);

            string result = string.Format(SuccessMessages.AddItemToPool, itemName);
            return result;
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (pool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            Item item = pool.Last();

            character.Bag.AddItem(item);
            pool.Pop();// do I?
            string result = string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
            return result;

        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];
            Character character = party.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);
            string result = string.Format(SuccessMessages.UsedItem, characterName, itemName);
            return result;


        }

        public string GetStats()
        { var partyItems = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);
            StringBuilder sb = new StringBuilder();
            foreach (var item in partyItems)
            { string status = item.IsAlive ? "Alive" : "Dead";
                sb.AppendLine(string.Format(SuccessMessages.CharacterStats, item.Name, item.Health, item.BaseHealth, item.Armor, item.BaseArmor, status));
            }
            return sb.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];
            Character attacker = party.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = party.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }
            
            var varAttacker = attacker as Warrior;

            if (varAttacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
            //if (!receiver.IsAlive)
            //{
            //    throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            //}
            varAttacker.Attack(receiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.AttackCharacter, attackerName, receiverName, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor));
            if (!receiver.IsAlive)
            {
                sb.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }
            
            return sb.ToString().TrimEnd(); // do i remove dead?
         
        }
    
        public string Heal(string[] args)
        {   
            string healerName = args[0];
            string healingReceiverName = args[1];
            Character healer = party.FirstOrDefault(x => x.Name == healerName);
            Character healingReceiver = party.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (healingReceiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }
            var varHealer = healer as Priest;
            if (varHealer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            varHealer.Heal(healingReceiver);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(SuccessMessages.HealCharacter, healerName, healingReceiverName, healer.AbilityPoints, healingReceiverName, healingReceiver.Health));
            
            return sb.ToString().TrimEnd();
        }
    }
}
