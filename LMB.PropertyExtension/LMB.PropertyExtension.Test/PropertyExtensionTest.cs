using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace LMB.PropertyExtension.Test
{
    [TestClass]
    public class PropertyExtensionTest
    {
        internal class Customer
        {
            [Display(Name = "Customer's Id")]
            public int Id { get; set; }

            [DisplayName("Customer's Full Name")]
            public string Name { get; set; }

            [Display(Name = "Customer's Category")]
            public CustomerCategory Category { get; set; }
        }

        internal enum CustomerCategory
        {

            [Display(Name = "Silver Category")]
            Silver = 1,

            [Display(Name = "Gold Category")]
            Gold = 2,

            [Display(Name = "Platinum Category")]
            Platinum = 3
        }

        [TestMethod]
        public void GetDisplayValueFromClass()
        {
            // Arrange
            var customer = new Customer
            {
                Category = CustomerCategory.Platinum,
                Id = 1,
                Name = "Homer 'Jay' Simpson"
            };

            // Act
            var nameAttribute = customer.GetDisplayAttributeValue("Id");

            // Assert
            Assert.IsTrue(nameAttribute.Equals("Customer's Id", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void GetDisplayNameValueFromClass()
        {
            // Arrange
            var customer = new Customer
            {
                Category = CustomerCategory.Platinum,
                Id = 1,
                Name = "Homer 'Jay' Simpson"
            };

            // Act
            var displayNameAttribute = customer.GetDisplayNameAttributeValue("Name");

            // Assert
            Assert.IsTrue(displayNameAttribute.Equals("Customer's Full Name", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod]
        public void GetDisplayValueFromEnum()
        {
            // Arrange

            // Act
            var nameAttribute = CustomerCategory.Gold.GetDisplayAttributeValue();

            // Assert
            Assert.IsTrue(nameAttribute.Equals("Gold Category", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}