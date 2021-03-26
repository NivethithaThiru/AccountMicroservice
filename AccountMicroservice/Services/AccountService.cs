using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountMicroservice.Models;
using AccountMicroservice.Repository;

namespace AccountMicroservice.Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountsRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountsRepository = accountRepository;
        }
        public List<AccountCreationStatus> CreateAccount(int customerId)
        {
            return _accountsRepository.CreateAccount(customerId);
        }
        public Account GetAccountDetails(int accountId)
        {
            return _accountsRepository.GetAccountDetails(accountId);
        }

        public List<Account> GetAllAccountDetails()
        {
            return _accountsRepository.GetAllAccountDetails();
        }

        public List<CustomerAccountDetails> GetCustomerAccountsDetails(int customerId)
        {
            return _accountsRepository.GetCustomerAccountsDetails(customerId);
        }

        public List<Statement> GetAccountStatement(int accountId, DateTime from_date, DateTime to_date)
        {
            return _accountsRepository.GetAccountStatement(accountId, from_date, to_date);
        }

        public List<Statement> GetAccountStatementByAccountId(int accountId)
        {
            return _accountsRepository.GetAccountStatementByAccountId(accountId);
        }

        public TransactionStatus Deposit(int accountId, double amount)
        {
            return _accountsRepository.Deposit(accountId, amount);

        }

        public TransactionStatus Withdraw(int accountId, double amount)
        {
            return _accountsRepository.Withdraw(accountId, amount);
        }

    }
}
