using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {   //bunny or I repo??
        private int eggsDone;
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;
        private IWorkshop workshop;
        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
            workshop = new Workshop();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            bunnies.Add(bunny);
            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);

        }

        public string AddDyeToBunny(string bunnyName, int power)
        {

            IBunny bunny = bunnies.FindByName(bunnyName);
            IDye dye = new Dye(power); //1 dif
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.AddDye(dye);
            return string.Format(OutputMessages.DyeAdded, power, bunnyName);

        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);
            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            List<IBunny> bunniesToWork = bunnies.Models.Where(x => x.Energy >= 50).OrderByDescending(x => x.Energy).ToList(); //2diff
           
            if (bunniesToWork.Count == 0) //== null 3 diff
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }
            string result = null;
            foreach (var bunny in bunniesToWork)
            {
                workshop.Color(egg, bunny);
                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }
                if (egg.IsDone())
                {
                    result = string.Format(OutputMessages.EggIsDone, eggName);
                    eggsDone++;
                    break;
                }
            }
            if (!egg.IsDone())
            {
                result = string.Format(OutputMessages.EggIsNotDone, eggName);
            }
            return result;

            /**/
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{eggsDone} eggs are done!");
            sb.AppendLine($"Bunnies info:");
            foreach (var bunny in bunnies.Models)
            { 
            //{   int dyesNotFinished = 0;
            //    foreach (var dye in bunny.Dyes)
            //    {
            //        if (!dye.IsFinished())
            //        {
            //            dyesNotFinished++;
            //        }
            //    }
                sb.AppendLine($"Name: {bunny.Name}");
                sb.AppendLine($"Energy: {bunny.Energy}");
                sb.AppendLine($"Dyes: {bunny.Dyes.Count} not finished");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
