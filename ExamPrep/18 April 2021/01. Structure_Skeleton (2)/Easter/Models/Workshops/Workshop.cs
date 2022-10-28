using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {

        public void Color(IEgg egg, IBunny bunny)
        {
            while (true)
            {
                if (bunny.Energy == 0)
                {
                    break;
                }
                if (bunny.Dyes.Count == 0)
                {
                    break;
                }
                if (egg.IsDone())
                {
                    break;
                }
                var dye = bunny.Dyes.FirstOrDefault();
                dye.Use();
                if (dye.IsFinished())
                {
                    bunny.Dyes.Remove(dye);
                }
                bunny.Work();
                egg.GetColored();
                
            }
            //while (bunny.Energy > 0 && bunny.Dyes.Count > 0)
            //{
            //    if (egg.IsDone())
            //    {
            //        break;
            //    }
            //    IDye dye = bunny.Dyes.First();
            //    while (!egg.IsDone())
            //    {   
            //        bunny.Work();
            //        dye.Use();
            //        egg.GetColored();
            //        if (dye.IsFinished())
            //        {
            //            bunny.Dyes.Remove(dye);
            //        }
            //        if (bunny.Energy == 0 || dye.IsFinished())
            //        {
            //            break;
            //        }
            //    }                
            //}
            /*Here is how the Color method works:
     •	The bunny starts coloring the egg. This is only possible, if the bunny has energy and an dye that isn't finished.
     •	At the same time the egg is getting colored, so call the GetColored() method for the egg. 
     •	Keep working until the egg is done or the bunny has energy and dyes to use.
     •	If at some point the power of the current dye reaches or drops below 0, meaning it is finished, then the Bunny should take the next Dye from its collection, if it has any left.
 */
        }
    }
}
