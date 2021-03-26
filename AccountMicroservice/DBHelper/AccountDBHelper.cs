using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountMicroservice.Models;

namespace AccountMicroservice.DBHelper
{
    public static class AccountDBHelper
    {
        public static List<Account> accounts = new List<Account>()
        {
             new Account(){ AccountId = 1001, CustomerId = 1000, AccountCreationDate = DateTime.Parse("2019-12-13"), AccountType = "Savings", CurrentBalance= 5000},
             new Account(){ AccountId = 1002, CustomerId = 1000, AccountCreationDate = DateTime.Parse("2019-12-13"), AccountType = "Current", CurrentBalance= 3000},
             new Account(){ AccountId = 1003, CustomerId = 1001, AccountCreationDate = DateTime.Parse("2020-08-01"), AccountType = "Current", CurrentBalance= 5000},
             new Account(){ AccountId = 1004, CustomerId = 1001, AccountCreationDate = DateTime.Parse("2020-08-01"), AccountType = "Savings", CurrentBalance= 3000},
             new Account(){ AccountId = 1005, CustomerId = 1002, AccountCreationDate = DateTime.Parse("2020-10-17"), AccountType = "Current", CurrentBalance= 5000},
             new Account(){ AccountId = 1006, CustomerId = 1002, AccountCreationDate = DateTime.Parse("2020-10-17"), AccountType = "Savings", CurrentBalance= 3000},
             new Account(){ AccountId = 1007, CustomerId = 1003, AccountCreationDate = DateTime.Parse("2021-01-22"), AccountType = "Current", CurrentBalance= 5000},
             new Account(){ AccountId = 1008, CustomerId = 1003, AccountCreationDate = DateTime.Parse("2021-01-22"), AccountType = "Savings", CurrentBalance= 3000}
        };


        public static List<AccountCreationStatus> accountCreationStatus = new List<AccountCreationStatus>();

        public static List<Statement> statements = new List<Statement>()
        {
            new Statement(){
                TransactionID = "TSC1010",
                AccountId = 1002,
                TransactionDate = DateTime.Parse("2021-02-24"),
                ValueDate = DateTime.Parse("2021-02-24"),
                Debit = 6000,
                Credit = 8000,
            },
            new Statement(){
                TransactionID = "TSC1020",
                AccountId = 1001,
                TransactionDate = DateTime.Parse("2021-03-01"),
                ValueDate = DateTime.Parse("2021-03-02"),
                Debit = 2000,
                Credit = 0,
            },
            new Statement(){
                TransactionID = "TSC1030",
                AccountId = 1001,
                TransactionDate = DateTime.Parse("2021-03-12"),
                ValueDate = DateTime.Parse("2021-03-12"),
                Debit = 4500,
                Credit = 18000,
            },
            new Statement(){
                TransactionID = "TSC1040",
                AccountId = 1002,
                TransactionDate = DateTime.Parse("2020-12-30"),
                ValueDate = DateTime.Parse("2021-01-30"),
                Debit = 9000,
                Credit = 20000,
            },
            new Statement(){
                TransactionID = "TSC1003",
                AccountId = 1003,
                TransactionDate = DateTime.Parse("2021-03-12"),
                ValueDate = DateTime.Parse("2021-03-12"),
                Debit = 4500,
                Credit = 18000,
            },
            new Statement(){
                TransactionID = "TSC1004",
                AccountId = 1004,
                TransactionDate = DateTime.Parse("2021-03-17"),
                ValueDate = DateTime.Parse("2021-01-30"),
                Debit = 9000,
                Credit = 20000,
            },
            new Statement(){
                TransactionID = "TSC1005",
                AccountId = 1003,
                TransactionDate = DateTime.Parse("2021-03-12"),
                ValueDate = DateTime.Parse("2021-03-12"),
                Debit = 6500,
                Credit = 18000,
            },
            new Statement(){
                TransactionID = "TSC1006",
                AccountId = 1004,
                TransactionDate = DateTime.Parse("2020-12-30"),
                ValueDate = DateTime.Parse("2021-01-30"),
                Debit = 6000,
                Credit = 35000,
            },
            new Statement(){
                TransactionID = "TSC1007",
                AccountId = 1005,
                TransactionDate = DateTime.Parse("2021-03-12"),
                ValueDate = DateTime.Parse("2021-03-12"),
                Debit = 4500,
                Credit = 18000,
            },
            new Statement(){
                TransactionID = "TSC1008",
                AccountId = 1005,
                TransactionDate = DateTime.Parse("2021-02-28"),
                ValueDate = DateTime.Parse("2021-01-30"),
                Debit = 7500,
                Credit = 15000,
            },
            new Statement(){
                TransactionID = "TSC1009",
                AccountId = 1006,
                TransactionDate = DateTime.Parse("2021-03-12"),
                ValueDate = DateTime.Parse("2021-03-12"),
                Debit = 3500,
                Credit = 14500,
            },
            new Statement(){
                TransactionID = "TSC1010",
                AccountId = 1007,
                TransactionDate = DateTime.Parse("2021-03-15"),
                ValueDate = DateTime.Parse("2021-01-30"),
                Debit = 7000,
                Credit = 22000,
            },
            new Statement(){
                TransactionID = "TSC1011",
                AccountId = 1008,
                TransactionDate = DateTime.Parse("2021-03-20"),
                ValueDate = DateTime.Parse("2021-01-30"),
                Debit = 7600,
                Credit = 17000,
            }
        };
        public static List<Account> getList()
        {
            return accounts;
        }
        public static List<AccountCreationStatus> getStatusList()
        {
            return accountCreationStatus;
        }
    }
}
