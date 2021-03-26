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

namespace AccountTesting
{
    [TestFixture]
    public class DepositTestingClass
    {
        private Mock<IAccountService> mockService;
        private AccountController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void Deposit_ValidData_ReturnsOkResult()
        {
            int accountId = 1001;
            double amount = 3000;
            TransactionStatus status = new TransactionStatus() { Message = "Completed", Updated_Balance = 8000 };
            mockService.Setup(s => s.Deposit(accountId, amount)).Returns(status);
            controller = new AccountController(mockService.Object);
            var result = controller.Deposit(accountId, amount);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Deposit_InvalidInput_ReturnsBadRequest()
        {
            int accountId = 90;
            double amount = 0;
            controller = new AccountController(mockService.Object);
            var result = controller.Deposit(accountId, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        [Test]
        public void Deposit_ValidData_ReturnsNoContent()
        {
            int accountId = 1001;
            double amount = 3000;
            TransactionStatus status = null;
            mockService.Setup(s => s.Deposit(accountId, amount)).Returns(status);
            controller = new AccountController(mockService.Object);
            var result = controller.Deposit(accountId, amount);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, okResult.StatusCode);
        }
    }
}
