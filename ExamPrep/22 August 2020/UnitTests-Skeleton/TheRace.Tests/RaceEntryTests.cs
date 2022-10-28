using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [Test]
        public void UnitCarConstructor()
        {

            string model = "Audi";
            int horsePower = 170;
            double cubicCentimeters = 2000;

            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);

            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(horsePower, car.HorsePower);
            Assert.AreEqual(cubicCentimeters, car.CubicCentimeters);
        }

        [Test]
        public void UnitDriverConstructor()
        {
            string model = "Audi";
            int horsePower = 170;
            double cubicCentimeters = 2000;
            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);

            string unitDriverName = "Alex";

            UnitDriver unitDriver = new UnitDriver(unitDriverName, car);

            Assert.IsNotNull(unitDriver);
            Assert.AreEqual(unitDriver.Car, car);
            Assert.AreEqual(unitDriver.Name, unitDriverName);
        }

        [Test]
        public void UnitDriverConstructorThowsExceptionForNullName()
        {
            string model = "Audi";
            int horsePower = 170;
            double cubicCentimeters = 2000;
            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);

            string unitDriverName = null;


            Assert.Throws<ArgumentNullException>(() => new UnitDriver(unitDriverName, car));
        }

        [Test]
        public void UnitDriverConstructorDontThrowExceptionForNullCar()
        {
            UnitCar car = null;
            string unitDriverName = "Alex";
            UnitDriver unitDriver = new UnitDriver(unitDriverName, car);

            Assert.IsNotNull(unitDriver);
            Assert.AreEqual(null, car);
            Assert.AreEqual(unitDriver.Name, unitDriverName);
        }

        [Test]
        public void RaceEntryConstructorSetDictionary()
        {
            RaceEntry race = new RaceEntry();
                        
            Assert.AreEqual(0, race.Counter);
        }

        [Test]
        public void AddDriverThrowsInvalidOperationExceptionForNullDriver()
        {
            UnitDriver unitDriver = null;
            RaceEntry race = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(unitDriver));
        }
        [Test]
        public void AddDriverThrowsInvalidOperationExceptionForExistingDriver()
        {
            string model = "Audi";
            int horsePower = 170;
            double cubicCentimeters = 2000;
            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver("Alex", car);
            RaceEntry race = new RaceEntry();
            race.AddDriver(unitDriver);

            string model1 = "BMW";
            int horsePower1 = 170;
            double cubicCentimeters1 = 2000;
            UnitCar car1 = new UnitCar(model1, horsePower1, cubicCentimeters1);
            UnitDriver unitDriver1 = new UnitDriver("Alex", car1);

            Assert.Throws<InvalidOperationException>(() => race.AddDriver(unitDriver1));
        }

        [Test]
        public void AddDriverWork()
        {
            string model = "Audi";
            int horsePower = 170;
            double cubicCentimeters = 2000;
            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver("Alex", car);
            RaceEntry race = new RaceEntry();
            string returned = race.AddDriver(unitDriver);
            string driver = "Driver Alex added in race.";

            Assert.AreEqual(1, race.Counter);
            Assert.AreEqual(driver, returned);

            string model1 = "Audi";
            int horsePower1 = 170;
            double cubicCentimeters1 = 2000;
            UnitCar car1 = new UnitCar(model1, horsePower1, cubicCentimeters1);
            UnitDriver unitDriver1 = new UnitDriver("Peter", car1);
            string driver1 = "Driver Peter added in race.";
            string returned1 = race.AddDriver(unitDriver1);

            Assert.AreEqual(driver1, returned1);
            Assert.AreEqual(2, race.Counter);
        }

        [Test]
        public void AverageHorsePowerWork()
        {
            string model = "Audi";
            int horsePower = 170;
            double cubicCentimeters = 2000;
            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver("Alex", car);
            RaceEntry race = new RaceEntry();
            string returned = race.AddDriver(unitDriver);
            string driver = "Driver Alex added in race.";

            Assert.AreEqual(1, race.Counter);
            Assert.AreEqual(driver, returned);

            string model1 = "Audi";
            int horsePower1 = 170;
            double cubicCentimeters1 = 2000;
            UnitCar car1 = new UnitCar(model1, horsePower1, cubicCentimeters1);
            UnitDriver unitDriver1 = new UnitDriver("Peter", car1);
            string driver1 = "Driver Peter added in race.";
            string returned1 = race.AddDriver(unitDriver1);

            Assert.AreEqual(driver1, returned1);
            Assert.AreEqual(2, race.Counter);
            Assert.AreEqual(170, race.CalculateAverageHorsePower());
        }

        [Test]
        public void AverageHorsePowerThrowsException()
        {
            string model = "Audi";
            int horsePower = 170;
            double cubicCentimeters = 2000;
            UnitCar car = new UnitCar(model, horsePower, cubicCentimeters);
            UnitDriver unitDriver = new UnitDriver("Alex", car);
            RaceEntry race = new RaceEntry();
            string returned = race.AddDriver(unitDriver);
            string driver = "Driver Alex added in race.";

            Assert.AreEqual(1, race.Counter);
            Assert.AreEqual(driver, returned);

           
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
            
        }
    }
}