using NUnit.Framework;
using System.Linq;
using System;

namespace Tests // Database
{   [TestFixture]
    public class DatabaseTests
    {   
        [Test]
        public void ConstructorShouldInitializeIntArray()
        {
            //Arrange
            int[] testArray = Enumerable.Range(1, 16).ToArray();
            //Act
            Database database = new Database(testArray);
            //Assert
            Assert.AreEqual(testArray.Count(), database.Count);
        }

        [Test]
        public void ConstructorShouldThrowInvalidOperationException()
        {
            //Arrange
            int[] testArray = Enumerable.Range(1, 17).ToArray();
            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(() => new Database(testArray));

        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AddMethodShouldAddOnNextFreeCell(int addedElements)
        {
            //Arrange
            int[] testArray = Enumerable.Range(1, 10).ToArray();
            //Act
            Database database = new Database(testArray);
            for (int i = 1; i <= addedElements; i++)
            {
            database.Add(testArray.Length + i);
            }
            //Assert
            Assert.AreEqual(testArray.Length + addedElements, database.Count);
        }


        [Test]
        public void AddMethodShouldThrowInvalidOperationExceptionIfAdding17Element()
        {
            //Arrange
            int[] testArray = Enumerable.Range(1, 16).ToArray();
            //Act
            Database database = new Database(testArray);
            //Assert
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void RemoveMethodShouldRemoveLastElement(int removedElements)
        {
            //Arrange
            int[] testArray = Enumerable.Range(1, 16).ToArray();
            //Act
            Database database = new Database(testArray);
            for (int i = 0; i < removedElements; i++)
            {
                database.Remove();
            }
            //Assert
            Assert.AreEqual(testArray.Length - removedElements, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowInvalidOperationExceptionIfArrayIsEmpty()
        {
            //Arrange
            //Act
            Database database = new Database();
            //Assert
            Assert.Throws<InvalidOperationException>( () => database.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnElementsAsArray()
        {
            //Arrange
            int[] testArray = Enumerable.Range(1, 16).ToArray();
            //Act
            Database database = new Database(testArray);
            //Assert
            CollectionAssert.AreEqual(testArray, database.Fetch());
        }
    }
}