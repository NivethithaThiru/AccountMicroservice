using System;
using System.Collections.Generic;
using AccountMicroservice;
using AccountMicroservice.Controllers;
using AccountMicroservice.Services;
using AccountMicroservice.Models;
using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AccountTesting
{
    [TestFixture]
    public class GetCustomerAccountsTestingClass
    {
        private Mock<IAccountService> mockService;
        private AccountController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void GetCustomerAccountDetails_ValidData_ReturnsOkResult()
        {
            int customerId = 12;
            List<CustomerAccountDetails> accountDetails = new List<CustomerAccountDetails>()
            {
                new CustomerAccountDetails() { AccountId =1003, CurrentBalance = 5000 },
                new CustomerAccountDetails() { AccountId =1004, CurrentBalance = 3000 }
            };

            mockService.Setup(s => s.GetCustomerAccountsDetails(customerId)).Returns(accountDetails);
            controller = new AccountController(mockService.Object);
            var result = controller.GetCustomerAccountDetails(customerId);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void GetCustomerAccountDetails_InvalidInput_ReturnsBadRequest()
        {
            var customerId = -99;
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.GetCustomerAccountDetails(customerId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result1);
        }

        [Test]
        public void GetCustomerAccountDetails_ValidData_ReturnsNoContent()
        {
            int customerId = 11;
            List<CustomerAccountDetails> accountDetails = new List<CustomerAccountDetails>();
            //var count = accountDetails.Count();
            mockService.Setup(s => s.GetCustomerAccountsDetails(customerId)).Returns(accountDetails);
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.GetCustomerAccountDetails(customerId);
            Assert.IsInstanceOf<NoContentResult>(result1);
        }
    }
}
