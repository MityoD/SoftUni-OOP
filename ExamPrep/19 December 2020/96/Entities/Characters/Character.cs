using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {

        private string name;
        private double baseHealth;
        private double health;
        private double baseArmor;
        private double abilityPoints;
        private Bag bag;
        private double armor;


        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.baseHealth = health;//starting
            this.Health = health;
            this.baseArmor = armor;
            this.Armor = armor;
            this.abilityPoints = abilityPoints;
            this.bag = bag;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }

        public double BaseHealth => baseHealth;


        public double Health//Health (current health) should never be more than the BaseHealth or less than 0. 

        {
            get { return health; }

            protected internal set
            {
                if (value > this.BaseHealth)
                {
                    value = this.BaseHealth;
                }

                if (value <= 0)
                {
                    this.IsAlive = false;
                    value = 0;
                }
                health = value;
            } //private ???
        }


        public double BaseArmor => baseArmor;

        public double Armor //Armor – the current amount of armor left – can not be less than 0.

        {
            get { return armor; }
            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                armor = value;
            }
        }


        public double AbilityPoints => abilityPoints;



        public Bag Bag => bag;
        // TODO: Implement the rest of the class.

        public bool IsAlive { get; set; } = true;

        protected internal void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            double pointsLeft = 0;
            if (this.Armor - hitPoints < 0)
            {
                pointsLeft = hitPoints - this.Armor;
                this.Armor = 0;
            }
            else
            {
                this.Armor -= hitPoints;
            }
            if (this.Health - pointsLeft < 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
            else
            {
                this.Health -= pointsLeft;
            }


        }

        protected internal void UseItem(Item item) // protected
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
            if (this.Health > this.BaseHealth)
            {
                this.Health = this.baseHealth;
            }

            if (this.Health < 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }


        }

        protected internal void EnsureAlive() //was protected
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}