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
    public class WithdrawTestingClass
    {
        private Mock<IAccountService> mockService;
        private AccountController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void Withdraw_ValidData_ReturnsOkResult()
        {
            int accountId = 1003;
            double amount = 2000;
            TransactionStatus status = new TransactionStatus() { Message = "Completed", Updated_Balance = 3000 };
            mockService.Setup(s => s.Withdraw(accountId, amount)).Returns(status);
            controller = new AccountController(mockService.Object);
            var result = controller.Withdraw(accountId, amount);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Withdraw_InvalidInput_ReturnsBadRequest()
        {
            int accountId = 90;
            double amount = 0;
            controller = new AccountController(mockService.Object);
            var result = controller.Withdraw(accountId, amount);
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }
        [Test]
        public void Withdraw_ValidData_ReturnsNoContent()
        {
            int accountId = 1003;
            double amount = 500;
            TransactionStatus status = null;
            mockService.Setup(s => s.Withdraw(accountId, amount)).Returns(status);
            controller = new AccountController(mockService.Object);
            var result = controller.Withdraw(accountId, amount);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(204, okResult.StatusCode);
        }
    }
}
