using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            string result = null;
            if (racerOne.IsAvailable() && racerTwo.IsAvailable())
            {    /*Map
Behavior
string StartRace(IRacer racerOne, IRacer racerTwo)
This method calls the two players for a race. When a race is being completed, the both racers should race. If one of the racers is not available for a race, the other one automatically wins the race. If both of the racers are not available for a race method returns a message saying that the race cannot be completed. When Racer race he drives his Car and gains driving experience. Also this method should calculate which one of the racers is the winner. The Racer chance of winning the race depends on his car's horse power, his driving experience and his racing behavior. The chance of winning a race is calculated by the car's horse power multiplied by driving experience multiplied by racing behavior multiplier. If the racing behavior is "strict" the multiplier is 1.2 and if the racing behavior is "aggressive" the multiplier is 1.1. All in all the chance of winning the race is:
	•	chanceOfWinning = horsePower * drivingExperience * racingBehaviorMultiplier

*/
                // didnt check for aggressive!!!
                string winner = null;
                racerOne.Race();
                racerTwo.Race();
                double racerOneMultiplyer = racerOne.RacingBehavior == "strict" ? 1.2 : 1.1;
                double racerTwoMultiplyer = racerTwo.RacingBehavior == "strict" ? 1.2 : 1.1;
                double racerOneChance = racerOne.Car.HorsePower * racerOne.DrivingExperience * racerOneMultiplyer;
                double racerTwoChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * racerTwoMultiplyer;
                if (racerOneChance > racerTwoChance)
                {
                    winner = racerOne.Username;
                }
                else if (racerOneChance < racerTwoChance)
                {
                    winner = racerTwo.Username;
                }
                result = string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner);
            }
            else if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                //both not available
                result = OutputMessages.RaceCannotBeCompleted;
            }
            else
            {
                if (!racerOne.IsAvailable())
                {
                    result = string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
                }
                else if (!racerTwo.IsAvailable())
                {
                    result = string.Format(OutputMessages.OneRacerIsNotAvailable,racerOne.Username, racerTwo.Username); 
                }
            }
            return result;
            /*Map
Behavior
string StartRace(IRacer racerOne, IRacer racerTwo)
This method calls the two players for a race. When a race is being completed, the both racers should race. If one of the racers is not available for a race, the other one automatically wins the race. If both of the racers are not available for a race method returns a message saying that the race cannot be completed. When Racer race he drives his Car and gains driving experience. Also this method should calculate which one of the racers is the winner. The Racer chance of winning the race depends on his car's horse power, his driving experience and his racing behavior. The chance of winning a race is calculated by the car's horse power multiplied by driving experience multiplied by racing behavior multiplier. If the racing behavior is "strict" the multiplier is 1.2 and if the racing behavior is "aggressive" the multiplier is 1.1. All in all the chance of winning the race is:
	•	chanceOfWinning = horsePower * drivingExperience * racingBehaviorMultiplier

*/
        }
    }
}
