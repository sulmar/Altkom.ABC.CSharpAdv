using System;
using System.Linq;
using Altkom.ABC.CSharpAdv.ConsoleClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altkom.ABC.CSharpAdv.UnitTests
{
    [TestClass]
    public class CustomersServiceUnitTest
    {
        [TestMethod]
        public void GetCustomersTest()
        {
            // Arrange
            ICustomersService customersService = new FakeCustomersService();

            // Acts
            var customers = customersService.Get();

            // Asserts
            Assert.IsNotNull(customers);
            Assert.IsTrue(customers.Any());
            Assert.AreEqual(100, customers.Count());

            
        }


        [TestMethod]
        public void CalculateTaxTest()
        {
            // Arrange
            TaxCalculator taxCalculator = new TaxCalculator();

            decimal amount = 100m;
            decimal tax = 1.23m;

            // Acts
            decimal result = taxCalculator.CalculateTax(amount, tax);

            // Assets

            Assert.AreEqual(123, result);

        }

        [TestMethod]
        public void CalculateTaxTest2()
        {
            // Arrange
            TaxCalculator taxCalculator = new TaxCalculator();

            decimal amount = 200m;
            decimal tax = 1.23m;

            // Acts
            decimal result = taxCalculator.CalculateTax(amount, tax);

            // Assets

            Assert.AreEqual(246, result);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateTaxZeroTest()
        {
            // Arrange
            TaxCalculator taxCalculator = new TaxCalculator();

            decimal amount = 0m;
            decimal tax = 1.23m;

            // Acts
            decimal result = taxCalculator.CalculateTax(amount, tax);

            // Assets

          

        }
    }
}
