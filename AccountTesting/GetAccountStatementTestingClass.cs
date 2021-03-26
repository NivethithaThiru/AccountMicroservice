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
    public class GetAccountStatementTestingClass
    {
        private Mock<IAccountService> mockService;
        private AccountController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void GetAccountStatement_ValidData_ReturnsOkResult()
        {
            int accountId = 1002;
            DateTime from_date = DateTime.Parse("2021-02-01");
            DateTime to_date = DateTime.Parse("2021-02-28");
            List<Statement> transaction_status = new List<Statement>()
            {
                new Statement {
                    TransactionID = "TSC1010",
                    AccountId = 1002,
                    TransactionDate = DateTime.Parse("2021-02-24"),
                    ValueDate = DateTime.Parse("2021-02-24"),
                    Debit = 6000,
                    Credit = 8000,
                    BalanceAmount = 5000
                }
            };
            mockService.Setup(s => s.GetAccountStatement(accountId, from_date, to_date)).Returns(transaction_status);
            controller = new AccountController(mockService.Object);
            var result = controller.GetAccountStatement(accountId, from_date, to_date);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void GetAccountStatement_InvalidInput_ReturnsBadRequest()
        {
            int accountId = 99;
            DateTime from_date = DateTime.Now.AddDays(1);
            DateTime to_date = DateTime.Now.AddDays(30);
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.GetAccountStatement(accountId, from_date, to_date);
            Assert.IsInstanceOf<BadRequestObjectResult>(result1);
        }

        [Test]
        public void GetAccountStatement_ValidData_ReturnsNoContent()
        {
            int accountId = 1002;
            DateTime from_date = DateTime.Parse("2021-02-01");
            DateTime to_date = DateTime.Parse("2021-02-28");
            List<Statement> transactionStatement = new List<Statement>();
            mockService.Setup(s => s.GetAccountStatement(accountId, from_date, to_date)).Returns(transactionStatement);
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.GetAccountStatement(accountId, from_date, to_date);
            Assert.IsInstanceOf<NoContentResult>(result1);
        }
    }
}
