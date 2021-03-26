using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountMicroservice.Services;
using AccountMicroservice.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //[HttpGet]
        //public IEnumerable<Account> GetAllAccounts()
        //{
        //    return _accountService.GetAllAccountDetails();
        //}

        // GET api/<AccountController>/5
        [HttpGet("getAccount")]
        public IActionResult GetAccount(int accountId)
        {
            if (accountId <= 999)
            {
                return BadRequest("Invalid AccountId");
            }
            else
            {
                Account account = _accountService.GetAccountDetails(accountId);
                if (account != null)
                {
                    return Ok(account);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpPost("createAccount")]
        public IActionResult CreateAccount(int customerId)
        {
            if (customerId <= 0)
            {
                return BadRequest("Invalid Customer Id");
            }
            else
            {
                List<AccountCreationStatus> status = _accountService.CreateAccount(customerId);
                if (status != null)
                {
                    return Ok(status);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpGet("GetCustomerAccountDetails")]
        public IActionResult GetCustomerAccountDetails(int customerId)
        {
            if (customerId <= 0)
            {
                return BadRequest("Invalid Customer Id");
            }
            else
            {
                List<CustomerAccountDetails> accountDetails = _accountService.GetCustomerAccountsDetails(customerId);
                if (accountDetails.Count == 0)
                {
                    //return BadRequest("No accounts found for your customer Id");
                    return NoContent();
                }
                else
                {
                    return Ok(accountDetails);
                }
            }
        }

        [HttpGet("GetAccountStatements")]
        public IActionResult GetAccountStatement(int accountId, DateTime from_date, DateTime to_date)
        {
            if (accountId <= 999 || from_date > DateTime.Now || to_date > DateTime.Now)
            {
                return BadRequest("Invalid information.");
            }
            else
            {
                List<Statement> transaction_Statement = _accountService.GetAccountStatement(accountId, from_date, to_date);
                if (transaction_Statement.Count > 0)
                    return Ok(transaction_Statement);
                else
                    return NoContent();
            }
        }

        [HttpGet("GetAccountStatementsByAccId")]
        public IActionResult GetAccountStatementByAccId(int accountId)
        {
            if (accountId <= 999)
            {
                return BadRequest("Invalid AccountId");
            }
            else
            {
                List<Statement> transaction_Statement = _accountService.GetAccountStatementByAccountId(accountId);
                if (transaction_Statement != null && transaction_Statement.Count > 0)
                {
                    return Ok(transaction_Statement);
                }
                else
                {
                    return NoContent();
                }
            }
        }

        [HttpPost("Deposit")]
        public IActionResult Deposit(int accountId, double amount)
        {
            if (accountId <= 999 || amount <= 0)
            {
                return BadRequest("Invalid details. Please enter the values correctly");
            }
            else
            {
                TransactionStatus transaction_status = _accountService.Deposit(accountId, amount);
                if (transaction_status != null)
                    return Ok(transaction_status);
                else
                    //return BadRequest("Account not found for entered account ID");
                    return NoContent();
            }
        }

        [HttpPost("Withdraw")]
        public IActionResult Withdraw(int accountId, double amount)
        {
            if (accountId <= 999 || amount <= 0)
            {
                return BadRequest("Invalid details. Please enter the values correctly");
            }
            else
            {
                TransactionStatus transaction_status = _accountService.Withdraw(accountId, amount);
                if (transaction_status != null)
                {
                    return Ok(transaction_status);
                }
                else
                    //return BadRequest("Account not found for entered account ID");
                    return NoContent();
            }
        }
    }
}

