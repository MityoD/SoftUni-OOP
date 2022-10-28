using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository : IRepository<IRace>
    {
        private readonly List<IRace> Models;

        public RaceRepository()
        {
            Models = new List<IRace>();
        }

        //public List<Race> Models { get; set; }

        public void Add(IRace model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IRace> GetAll() => Models as IReadOnlyCollection<IRace>;

        //TODO

        public IRace GetByName(string name) => Models.FirstOrDefault(x => x.Name == name);
        //=> Models.FirstOrDefault(x => x.Model == name);

        public bool Remove(IRace model) => Models.Remove(model);
    }
}
