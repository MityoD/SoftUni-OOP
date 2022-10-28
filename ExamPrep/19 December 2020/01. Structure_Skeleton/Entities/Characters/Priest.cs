using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Priest : Character, IHealer
    {
        public Priest(string name) 
            : base(name, 50, 25, 40, new Backpack())
        {
        }

        public void Heal(Character character)
        {
            character.EnsureAlive();
            this.EnsureAlive();
                //If this is true, the receiving character’s health increases by the healer’s ability points.
                character.Health += this.AbilityPoints;

        }
    }
}
