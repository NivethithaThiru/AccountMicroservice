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
    public class GetAccountStatementByAccIdTestingClass
    {
        private Mock<IAccountService> mockService;
        private AccountController controller;

        [SetUp]
        public void SetUp()
        {
            mockService = new Mock<IAccountService>();
        }

        [Test]
        public void GetAccountStatementByAccId_ValidData_ReturnsOkResult()
        {
            int accountId = 1001;
            List<Statement> transaction_status = new List<Statement>()
            {
               new Statement(){
                    TransactionID = "TSC1020",
                    AccountId = 1001,
                    TransactionDate = DateTime.Parse("2021-03-01"),
                    ValueDate = DateTime.Parse("2021-03-02"),
                    Debit = 2000,
                    Credit = 0,
                    BalanceAmount = 3000
                },
                new Statement(){
                    TransactionID = "TSC1030",
                    AccountId = 1001,
                    TransactionDate = DateTime.Parse("2021-03-12"),
                    ValueDate = DateTime.Parse("2021-03-12"),
                    Debit = 4500,
                    Credit = 18000,
                    BalanceAmount = 16500
                }
            };
            mockService.Setup(s => s.GetAccountStatementByAccountId(accountId)).Returns(transaction_status);
            controller = new AccountController(mockService.Object);
            var result = controller.GetAccountStatementByAccId(accountId);
            var okResult = (IStatusCodeActionResult)result;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void GetAccountStatementByAccId_InvalidInput_ReturnsBadRequest()
        {
            int accountId = 99;
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.GetAccountStatementByAccId(accountId);
            Assert.IsInstanceOf<BadRequestObjectResult>(result1);
        }

        [Test]
        public void GetAccountStatementByAccId_ValidData_ReturnsNoContent()
        {
            int accountId = 1002;
            List<Statement> transactionStatement = new List<Statement>();
            mockService.Setup(s => s.GetAccountStatementByAccountId(accountId)).Returns(transactionStatement);
            controller = new AccountController(mockService.Object);
            IActionResult result1 = controller.GetAccountStatementByAccId(accountId);
            Assert.IsInstanceOf<NoContentResult>(result1);
        }
    }
}
