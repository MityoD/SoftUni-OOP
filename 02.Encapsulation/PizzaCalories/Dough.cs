using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private const double baseCalories = 2;
        private string flourType;
        private string bakingTechnique;
        private double grams;

        private double flourCalorier;
        private double bakingCalories;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        private string FlourType
        {

            set
            {
                if (string.Equals(value, "White", StringComparison.OrdinalIgnoreCase))
                {
                    flourCalorier = 1.5;                    
                }
                else if (string.Equals(value, "Wholegrain", StringComparison.OrdinalIgnoreCase))
                {
                    flourCalorier = 1;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
                flourType = value;

            }

        }
        private string BakingTechnique
        {
            set
            {
                if (string.Equals(value, "Crispy", StringComparison.OrdinalIgnoreCase))
                {
                    bakingCalories = 0.9;
                }
                else if (string.Equals(value, "Chewy", StringComparison.OrdinalIgnoreCase))
                {
                    bakingCalories = 1.1;
                }
                else if (string.Equals(value, "Homemade", StringComparison.OrdinalIgnoreCase))
                {
                    bakingCalories = 1;
                }
                else
                {
                    throw new Exception("Invalid type of dough.");
                }
                bakingTechnique = value;
            }
        }
        private double Grams
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                grams = value;
            }
        }

        public double CalculateCalories()
        {
            return baseCalories * flourCalorier * bakingCalories * grams;
        }

    }
}
