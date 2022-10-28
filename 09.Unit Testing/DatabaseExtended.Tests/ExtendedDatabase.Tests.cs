using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests //ExtendedDatabase
{
    public class ExtendedDatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(9999999991, "userOne")]
        [TestCase(9999999992, "userTwo")]
        [TestCase(9999999993, "userThree")]
        public void PersonConstructorShouldAddVauesForIDAndUsername(long ID, string userName)
        {
            Person person = new Person(ID, userName);

            Assert.AreEqual(ID, person.Id);
            Assert.AreEqual(userName, person.UserName);
        }

        [Test]
        public void DatabaseConstructorShouldAddPersonParams()
        {
            Person[] persons = new Person[]
            {
            new Person(9999999991, "userOne"),
            new Person(9999999992, "userTwo"),
            new Person(9999999993, "userThree")
            };

            ExtendedDatabase database = new ExtendedDatabase(persons);

            Assert.AreEqual(persons.Count(), database.Count);
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(16)]
        public void AddUserShouldAddUntilCountIsValid(int data)
        {

            long baseId = 9999999990;
            string baseUserName = "user";
            ExtendedDatabase database = new ExtendedDatabase();
            for (int i = 0; i < data; i++)
            {
                long personID = baseId + i;
                string personUserName = baseUserName + i.ToString();
                Person person = new Person(personID, personUserName);
                database.Add(person);
            }

            Assert.AreEqual(data, database.Count);
        }

        [Test]
        public void AddUserShouldThrowInvalidOperationExceptionForSameId()
        {
            Person[] persons = new Person[]
            {
            new Person(9999999991, "userOne"),
            new Person(9999999992, "userTwo"),
            new Person(9999999993, "userThree")
            };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Person person = new Person(9999999993, "userFour");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void AddUserShouldThrowInvalidOperationExceptionForSameUserName()
        {
            Person[] persons = new Person[]
            {
            new Person(9999999991, "userOne"),
            new Person(9999999992, "userTwo"),
            new Person(9999999993, "userThree")
            };
            ExtendedDatabase database = new ExtendedDatabase(persons);

            Person person = new Person(9999999994, "userThree");

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [Test]
        public void AddUserShouldThrowInvalidOperationExceptionForAddingMoreThan16Persons()
        {
            long baseId = 9999999990;
            string baseUserName = "user";

            ExtendedDatabase database = new ExtendedDatabase();
            for (int i = 0; i < 16; i++)
            {
                long personID = baseId + i;
                string personUserName = baseUserName + i.ToString();
                Person person = new Person(personID, personUserName);
                database.Add(person);
            }
            Person extraPerson = new Person(123, "extraPerson");
            Assert.Throws<InvalidOperationException>(() => database.Add(extraPerson));
        }


        [Test]
        public void AddRangeShouldThrowArgumentExceptionForAddingMoreThan16Persons()
        {
            long baseId = 9999999990;
            string baseUserName = "user";

            List<Person> persons = new List<Person>();
            for (int i = 0; i < 17; i++)
            {
                long personID = baseId + i;
                string personUserName = baseUserName + i.ToString();
                Person person = new Person(personID, personUserName);
                persons.Add(person);
            }
            Person[] databasePersons = persons.ToArray();

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(databasePersons));
        }

        [Test]
        [TestCase(10, 5)]
        [TestCase(16, 3)]
        [TestCase(5, 2)]
        public void RemoveShouldDeleteLastElement(int addData, int removeData)
        {
            long baseId = 9999999990;
            string baseUserName = "user";

            ExtendedDatabase database = new ExtendedDatabase();
            for (int i = 0; i < addData; i++)
            {
                long personID = baseId + i;
                string personUserName = baseUserName + i.ToString();
                Person person = new Person(personID, personUserName);
                database.Add(person);
            }
            for (int j = 0; j < removeData; j++)
            {
                database.Remove();
            }
            Assert.AreEqual(addData - removeData, database.Count);
        }

        [Test]
        public void RemoveShouldThrowInvalidOperationExceptionWhenCollectionIsEmpty()
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameShouldThrowArgumentNullExceptionIfUserNameIsNullOrEmpti(string userName)
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(userName));
        }

        [Test]
        [TestCase(10)]
        [TestCase(16)]
        [TestCase(5)]
        public void FindByUsernameShouldThrowInvalidOperationExceptionIfUserNameNotPresent(int addData)
        {
            long baseId = 9999999990;
            string baseUserName = "user";

            ExtendedDatabase database = new ExtendedDatabase();
            for (int i = 0; i < addData; i++)
            {
                long personID = baseId + i;
                string personUserName = baseUserName + i.ToString();
                Person person = new Person(personID, personUserName);
                database.Add(person);
            }
            string invalidUsername = "someUserName";

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(invalidUsername));
        }

        [Test]
        public void FindByUsernameShouldReturnValidPersonForValidUserName()
        {
            long baseId = 9999999990;
            string baseUserName = "user";
            Person person = new Person(baseId, baseUserName);
            ExtendedDatabase database = new ExtendedDatabase(person);
            Person validPerson = database.FindByUsername(baseUserName);

            Assert.AreEqual(person, validPerson);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void FindByIDShouldThrowArgumentOutOfRangeExceptionForNegativeID(long idNumber)
        {

            ExtendedDatabase database = new ExtendedDatabase();


            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(idNumber));
        }

        [Test]
        [TestCase(999999999)]
        [TestCase(989892009)]
        [TestCase(100123323)]
        public void FindByIDShouldThrowInvalidOperationExceptionForInvalidID(long idNumber)
        {
            ExtendedDatabase database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.FindById(idNumber));
        }

        [Test]
        [TestCase(9999999999)]
        [TestCase(9999999929)]
        [TestCase(2839293932)]
        public void FindByIDShouldReturnPersonForValidID(long idData)
        {
            string baseUserName = "user";
            Person person = new Person(idData, baseUserName);

            ExtendedDatabase database = new ExtendedDatabase(person);

            Person personByID = database.FindById(idData);

            Assert.AreEqual(person, personByID);
        }
    }
}