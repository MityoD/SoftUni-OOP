using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        public ProfessionalRacer(string username,ICar car) 
            : base(username, "strict", 30, car)
        {
        }
        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10; 

            /*When the Race() method is being called, the Racer's car is beign driven. Also everytime Racer is racing, his driving experience is being increased depending on the racer type. ProfessionalRacer increases his driving experience with 10 everytime he races and StreetRacer increases his driving experience with 5 every time he races. 
*/
        }
    }
}
