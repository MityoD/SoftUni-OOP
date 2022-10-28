using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar> //!!!!!Interface in repository!!!
    {
        private readonly List<ICar> Models; // = new List<ICar>();

        public CarRepository()
        {
            Models = new List<ICar>();
        }

        public void Add(ICar model)
        {
            Models.Add(model);
        }

        public IReadOnlyCollection<ICar> GetAll() => Models as IReadOnlyCollection<Car>;

        //TODO

        public ICar GetByName(string name) => Models.FirstOrDefault(x => x.Model == name);
        //Models.FirstOrDefault(x => x.GetType().Name == name);
        // 
        //;


        public bool Remove(ICar model) => Models.Remove(model);
        
    }
}
