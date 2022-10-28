using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();

        public void Add(IPlanet model)
        {
            models.Add(model);
        }

        public IPlanet FindByName(string name) => models.First(x => x.Name == name); //FirstOrDefault

        public bool Remove(IPlanet model) => models.Remove(model);
    }
}

