using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private readonly List<IDriver> Models;

        public DriverRepository()
        {
            Models = new List<IDriver>();
        }

        public void Add(IDriver model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<IDriver> GetAll() => Models as IReadOnlyCollection<IDriver>;

        //TODO

        public IDriver GetByName(string name) => Models.FirstOrDefault(x => x.Name == name);
        //=> Models.FirstOrDefault(x => x.Model == name);

        public bool Remove(IDriver model) => Models.Remove(model);
    }
}
