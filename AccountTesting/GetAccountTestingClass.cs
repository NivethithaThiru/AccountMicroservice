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
    [TestFixture]
    public class GetAccountTestingClass
    {
        private Mock<IAccountService> mockService;
        private AccountController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void GetAccount_ValidData_ReturnsOkResult()
        {
            int accountId = 1002;
            Account account = new Account() { AccountId = 1002, CustomerId = 10, AccountCreationDate = DateTime.Parse("2019-12-13"), AccountType = "Current", CurrentBalance = 3000 };
            mockService.Setup(s => s.GetAccountDetails(accountId)).Returns(account);
            controller = new AccountController(mockService.Object);
            var result = controller.GetAccount(accountId);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void GetAccount_InvalidInput_ReturnsBadRequest()
        {
            var accountId = 0;
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.GetAccount(accountId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result1);
        }

        [Test]
        public void GetAccount_ValidData_ReturnsNoContent()
        {
            var accountId = 1011;
            Account account = null;
            mockService.Setup(s => s.GetAccountDetails(accountId)).Returns(account);
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.CreateAccount(accountId);
            Assert.IsInstanceOf<NoContentResult>(result1);
        }
    }
}
