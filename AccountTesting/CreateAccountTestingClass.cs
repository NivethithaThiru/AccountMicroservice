using System;
using AccountMicroservice;
using AccountMicroservice.Controllers;
using AccountMicroservice.Services;
using AccountMicroservice.Models;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AccountTesting
{
    public class CreateAccountTestingClass
    {
        private Mock<IAccountService> mockService;
        private AccountController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void CreateAccount_ValidData_ReturnsOkResult()
        {
            List<AccountCreationStatus> stmt = new List<AccountCreationStatus>()
            {
                new AccountCreationStatus{ AccountId = 1005, Message = "Savings Account created successfully" },
                new AccountCreationStatus{ AccountId = 1006, Message = "Current Account cretaed successfully"}
            };

            var customerId = 12;
            mockService.Setup(s => s.CreateAccount(customerId)).Returns(stmt);
            controller = new AccountController(mockService.Object);
            var result = controller.CreateAccount(customerId);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void CreateAccount_InvalidInput_ReturnsBadRequest()
        {
            var customerId = 0;
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.CreateAccount(customerId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result1);
        }

        [Test]
        //[ExpectedException]
        public void CreateAccount_ValidData_ReturnsNoContent()
        {
            var customerId = 1011;
            List<AccountCreationStatus> stmt = null;
            mockService.Setup(s => s.CreateAccount(customerId)).Returns(stmt);
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.CreateAccount(customerId);
            Assert.IsInstanceOf<NoContentResult>(result1);
        }
    }
}
