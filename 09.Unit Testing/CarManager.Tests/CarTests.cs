using NUnit.Framework;
using System;
using System.Reflection;

namespace Tests //CarManager 
{
    public class CarTests
    {

        [Test]
        [TestCase("Mazda","3",10,50)]
        [TestCase("Audi","A4",7.5,60)]
        [TestCase("BMW","M5",12,70)]
        public void ConstructorShouldInitializeCar(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(null, "3", 10, 50)]
        [TestCase("", "3", 10, 50)]
        [TestCase("Audi", null, 7.5, 60)]
        [TestCase("Audi", "", 7.5, 60)]
        [TestCase("BMW", "M5", 0, 70)]
        [TestCase("BMW", "M5", -5, 70)]
        [TestCase("BMW", "X6", 12, 0)]
        [TestCase("BMW", "X6", 12, -70)]
        public void ConstructorShouldThrowArgumentExceptionForInvalidProperties(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase("Mazda", "3", 10, 50, -1)]
        [TestCase("Audi", "A4", 7.5, 60, -10)]
        [TestCase("BMW", "M5", 12, 70, -100)]
        public void FuelAmoundShouldThrowArgumenExceptionForNegativeValue(string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
            string msg = "Fuel amount cannot be zero or negative!";
            try
            {
                car.Refuel(fuelAmount);
            }
            catch (Exception error)
            {
                Assert.AreEqual(msg, error.Message);
            }
        }

        [Test]
        [TestCase("Mazda", "3", 10, 50, 30)]
        [TestCase("Audi", "A4", 7.5, 60, 45)]
        [TestCase("BMW", "M5", 12, 70, 70)]
        public void RefuelShouldAddFuelValueIfPositiveAndLessThanCapacity(string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(fuelAmount);
            Assert.AreEqual(fuelAmount, car.FuelAmount);
        }

        [Test]
        [TestCase("Mazda", "3", 10, 50, -30)]
        [TestCase("Audi", "A4", 7.5, 60, -45)]
        [TestCase("BMW", "M5", 12, 70, -70)]
        public void RefuelShouldThrowArgumenExceptionForNegativeValue(string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        [TestCase("Mazda", "3", 10, 50, 130)]
        [TestCase("Audi", "A4", 7.5, 60, 145)]
        [TestCase("BMW", "M5", 12, 70, 72)]
        public void RefuelShouldAddOnlyFuelEqualToCapacity(string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelAmount);
            Assert.AreEqual(fuelCapacity, car.FuelAmount);
        }

        [Test]
        [TestCase("Mazda", "3", 10, 50, 10, 101)]
        [TestCase("Audi", "A4", 7.5, 60, 5, 150)]
        [TestCase("BMW", "M5", 12, 70, 2, 50)]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelIsNotEnought(string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount, double distance)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelAmount);
            Assert.Throws<InvalidOperationException>(() => car.Drive(distance));
        }

        [Test]
        [TestCase("Mazda", "3", 10, 50, 10, 100)]
        [TestCase("Audi", "A4", 5, 60, 20, 200)]
        [TestCase("BMW", "M5", 14, 70, 60, 150)]
        public void DriveShouldReduceFuelAmountWhenUsed(string make, string model, double fuelConsumption, double fuelCapacity, double fuelAmount, double distance)
        {
            double fuelNeeded = (distance / 100) * fuelConsumption;
            double expectedFuelLeft = fuelAmount - fuelNeeded;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelAmount);
            car.Drive(distance);
            Assert.AreEqual(expectedFuelLeft, car.FuelAmount);
        }
    }
}