using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{
    public class Tests
    {

        [Test]
        public void ConstructorShouldWork()
        {
            ComputerManager computerManager = new ComputerManager();

            Assert.AreEqual(0, computerManager.Count);
            Assert.AreEqual(0, computerManager.Computers.Count);
            Assert.IsNotNull(computerManager.Computers);
        }

        [Test]
        public void ComputerConstructorShouldWork()
        {
            Computer computer = new Computer("HP", "model", 1500m);

            Assert.AreEqual("HP", computer.Manufacturer);
            Assert.AreEqual("model", computer.Model);
            Assert.AreEqual(1500m, computer.Price);
        }

        [Test]
        public void AddWorkCorrectForOne()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer);

            Assert.AreEqual(1, computerManager.Count);
            Assert.AreEqual(1, computerManager.Computers.Count);
            CollectionAssert.Contains(computerManager.Computers, computer);

        }
        [Test]
        public void AddWorkCorrectForMultiple()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "otherModel", 1500m);
            Computer computer2 = new Computer("Asus", "model", 1500m);
            Computer computer3 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);

            Assert.AreEqual(3, computerManager.Count);
            Assert.AreEqual(3, computerManager.Computers.Count);
            CollectionAssert.Contains(computerManager.Computers, computer1);
            CollectionAssert.Contains(computerManager.Computers, computer2);
            CollectionAssert.Contains(computerManager.Computers, computer3);

        }

        [Test]
        public void AddValidateNullValueWork()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = null;

            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(computer));
            string msg = "Can not be null!";
            string msg2 = "";
            try
            {
                computerManager.AddComputer(computer);
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex.Message.Contains(msg));
            }   
            

        }

        [Test]
        public void AddThrowsArgumentException()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            Computer computer2 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentException>(() => computerManager.AddComputer(computer2));

        }

        [Test]
        [TestCase("HP", null)]
    
        public void GetComputerNullValidation(string manufacturer, string model)
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacturer, model));

        }
        [Test]
        [TestCase(null, "Yoga")]
        public void GetComputerNullValidation2(string manufacturer, string model)
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacturer, model));

        }

        [Test]
        [TestCase("Asus", "Model")]
        public void GetComputerThrowsArgumentException(string manufacturer, string model)
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentException>(() => computerManager.GetComputer(manufacturer, model));

        }

        [Test]
        public void GetComputerReturnComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Assert.IsNotNull(computerManager.GetComputer("HP", "model"));
            Assert.AreEqual(computer1, computerManager.GetComputer("HP", "model"));
        }

        [Test]
        public void GetComputersByManufacturerThrowsArgumentNullException()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            string manufacturer = null;

            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputersByManufacturer(manufacturer));
        }

        [Test]
        public void GetComputersByManufacturerReturnCollection()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model1", 1500m);
            Computer computer2 = new Computer("HP", "model2", 1500m);
            Computer computer3 = new Computer("HP", "model3", 1500m);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);
            string manufacturer = "HP";

            List<Computer> computers = new List<Computer>();
            computers.Add(computer1);
            computers.Add(computer2);
            computers.Add(computer3);
            Assert.AreEqual(3, computerManager.GetComputersByManufacturer(manufacturer).Count);

            CollectionAssert.AreEqual(computers, computerManager.GetComputersByManufacturer(manufacturer));

        }

        [Test]
        public void GetComputersByManufacturerReturnCollectionEmpty()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model1", 1500m);
            Computer computer2 = new Computer("HP", "model2", 1500m);
            Computer computer3 = new Computer("HP", "model3", 1500m);
            computerManager.AddComputer(computer1);
            computerManager.AddComputer(computer2);
            computerManager.AddComputer(computer3);
            string manufacturer = "Dell";

            List<Computer> computers = new List<Computer>();
        
            Assert.AreEqual(0, computerManager.GetComputersByManufacturer(manufacturer).Count);

            CollectionAssert.AreEqual(computers, computerManager.GetComputersByManufacturer(manufacturer));

        }

        [TestCase("HP", null)]

        public void RemoveComputerNullValidation(string manufacturer, string model)
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(manufacturer, model));
        }
        [TestCase(null, "Yoga")]
        public void RemoveComputerNullValidation2(string manufacturer, string model)
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Assert.Throws<ArgumentNullException>(() => computerManager.RemoveComputer(manufacturer, model));
        }

        [Test]
        public void RemoveComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer1 = new Computer("HP", "model", 1500m);
            computerManager.AddComputer(computer1);

            Computer removedComputer = computerManager.RemoveComputer("HP", "model");
            Assert.AreEqual(computer1, removedComputer);
            Assert.AreEqual(0, computerManager.Count);

        }
    }
}