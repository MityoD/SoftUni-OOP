using System;
using System.Collections.Generic;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBaseHero> heroes = new List<IBaseHero>();

            int num = int.Parse(Console.ReadLine());

            while (heroes.Count != num)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Paladin":
                        IBaseHero paladin = new Paladin(heroName);
                        heroes.Add(paladin);
                        break;
                    case "Warrior":
                        IBaseHero warrior = new Warrior(heroName);
                        heroes.Add(warrior);
                        break;
                    case "Rogue":
                        IBaseHero rogue = new Rogue(heroName);
                        heroes.Add(rogue);
                        break;
                    case "Druid":
                        IBaseHero druid = new Druid(heroName);
                        heroes.Add(druid);
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int totalPower = 0;

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalPower += hero.Power;
            }

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
