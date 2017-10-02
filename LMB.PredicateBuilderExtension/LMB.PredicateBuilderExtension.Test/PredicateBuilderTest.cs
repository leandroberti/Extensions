using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LMB.PredicateBuilderExtension.Test
{
    [TestClass]
    public class PredicateBuilderTest
    {
        internal class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private static ICollection<Person> Persons;

        [ClassInitialize()]
        public static void PrepareData(TestContext context)
        {
            Persons = new List<Person>
            {
                { new Person {   Name  = "Albert", Age = 31 } },
                {  new Person {   Name  = "Amanda" , Age = 18 } },
                {  new Person {   Name  = "Angelina" , Age = 23 } },
                {  new Person {   Name  = "Bishop", Age = 28 } },
                {  new Person {   Name  = "Brad", Age = 35 } },
                {  new Person {   Name  = "Dilbert", Age = 50 } },
                {  new Person {   Name  = "Lilith", Age = 8 } },
                {  new Person {   Name  = "Lindsey", Age = 29 }  },
                {  new Person {   Name  = "Tom", Age = 30 }  }
            };
        }

        [TestMethod]
        public void AndPredicateTest()
        {
            // Arrange
            var predicate = PredicateBuilderExtension.True<Person>();
            predicate = predicate.And(x => x.Name.StartsWith("A"));

            // Act
            var queryResult = Persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.IsTrue(queryResult.Count == 3);
        }

        [TestMethod]
        public void OrPredicateTest()
        {
            // Arrange
            var predicate = PredicateBuilderExtension.True<Person>();
            predicate = predicate.And(x => x.Name.StartsWith("A"));
            predicate = predicate.Or(x => x.Name.StartsWith("B"));

            // Act
            var queryResult = Persons.AsQueryable().Where(predicate).ToList();

            // Assert
            Assert.IsTrue(queryResult.Count == 5);
        }
    }
}
