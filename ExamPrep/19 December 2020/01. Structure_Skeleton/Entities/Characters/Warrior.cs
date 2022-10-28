using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character , IAttacker
    {
        public Warrior(string name) 
            : base(name, 100, 50, 40, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            /*For a character to attack another character, both of them need to be alive.
If the character they are trying to attack is the same character, throw an InvalidOperationException with the message "Cannot attack self!"
If all of those checks pass, the receiving character takes damage equal to the attacking character’s ability points. The damage is subtracted from the armor points first and once there is no more armor points, from the health points of the receiver.  */
                this.EnsureAlive();
                character.EnsureAlive();
                if (character == this)//???
                {
                    throw new InvalidOperationException(ExceptionMessages.CharacterAttacksSelf);
                }
                double atackAbilityPoints = this.AbilityPoints;
                character.TakeDamage(atackAbilityPoints); 

        }
    }
}
