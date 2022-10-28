using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IAstronaut> astronautRepository;
        private readonly IRepository<IPlanet> planetRepository;
        private readonly IMission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            astronautRepository = new AstronautRepository();
            planetRepository = new PlanetRepository();
            mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {

            IAstronaut astronaut;

            switch (type)
            {
                case nameof(Biologist):
                    astronaut = new Biologist(astronautName);
                    break;

                case nameof(Geodesist):
                    astronaut = new Geodesist(astronautName);
                    break;
                case nameof(Meteorologist):
                    astronaut = new Meteorologist(astronautName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            astronautRepository.Add(astronaut);

            return string.Format(OutputMessages.AstronautAdded, type, astronautName);

        }

        public string AddPlanet(string planetName, params string[] items)
        {

            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
            {
                planet.Items.Add(item);
            }

            planetRepository.Add(planet);

            return string.Format(OutputMessages.PlanetAdded, planetName);
          
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planetRepository.FindByName(planetName);

            List<IAstronaut> astronauts = astronautRepository.Models.Where(x => x.Oxygen > 60).ToList();

            if (astronauts.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            mission.Explore(planet, astronauts);
            exploredPlanetsCount++;
            int deadAstronauts = astronauts.Where(x => x.CanBreath == false).Count(); //???
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
                       
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanetsCount} planets were explored!");
            sb.AppendLine($"Astronauts info:");

            foreach (var astronaut in astronautRepository.Models)
            { string items = astronaut.Bag.Items.Count == 0 ? "none" : string.Join(", ", astronaut.Bag.Items);
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.AppendLine($"Bag items: {items}");
            }

            return sb.ToString().TrimEnd();
            /*Returns the information about the astronauts. If any of them doesn't have bag items, print "none" instead.
"{exploredPlanetsCount} planets were explored!Astronauts info:Name: {astronautName}Oxygen: {astronautOxygen}Bag items: {bagItem1, bagItem2, …, bagItemn} / none…Name: {astronautName}Oxygen: {astronautOxygen}Bag items: {bagItem1, bagItem2, …, bagItemn} / none"
Note: Use \r\n or Environment.NewLine for a new line.*/
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            astronautRepository.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);


        }
    }
}
