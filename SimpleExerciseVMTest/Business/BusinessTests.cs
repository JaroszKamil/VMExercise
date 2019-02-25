using BusinessLayer;
using BusinessLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SimpleExerciseVMTests
{
    [TestClass]
    public class BusinessTests:BaseTest
    {
        [TestMethod]
        public void CreateCustomer_ValidInput_ReturnSuccess()
        {
            Customer customer = new Customer
            {
                CustomerId ="3",
                Name = "UnitTest",
                Addresses = new List<Address>
                {
                   new Address
                   {
                       AddressType = "I",
                       City = "Gdañsk",
                       Country = "PL",
                       Street = "Wiejska",
                       ZIP = "02-200"
                   }
                }
            };

            var result = service.CreateCustomer(customer);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void DeleteCustomer_ValidInput_ReturnSuccess()
        {
            //Customer customer = new Customer
            //{
            //    CustomerId = "3",
            //    Name = "UnitTest",
            //    Addresses = new List<Address>
            //    {
            //       new Address
            //       {
            //           AddressType = "I",
            //           City = "Gdañsk",
            //           Country = "PL",
            //           Street = "Wiejska",
            //           ZIP = "02-200"
            //       }
            //    }
            //};

            var results = service.DeleteCustomer("3", "UnitTest");
            Assert.IsTrue(results);
            
        }
    }
}
