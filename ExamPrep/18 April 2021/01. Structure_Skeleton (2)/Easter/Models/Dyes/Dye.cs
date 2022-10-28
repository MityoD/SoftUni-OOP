using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get => power;

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }
                power = value;
            }
        }



        public bool IsFinished() => this.Power == 0;

        public void Use()
        {//The Use() method decreases the Dye's power by 10. 
           // An Dye's power should not drop below 0, if the power becomes less than 0, set it to 0
            this.Power -= 10;
        }
    }
}
