using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObjectIntro.Classes.BankAccount
{
    public class BankAccount
    {
        //DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        //Constructor
        public BankAccount(decimal balance = 0)
        {
            Balance = balance;
            OpeningDate = DateTime.Today;
            OverDraft = 0;

            
        }

        //Properties
        public decimal Balance{ get; private set; } 
        public DateTime OpeningDate { get; private set; }
        public decimal OverDraft { get; set;}

        public void Deposit(decimal money)
        {
            Balance += money;
        }

        public bool Withdraw(decimal money)
        {
            if (Balance - money > OverDraft) { Balance -= money; return true; }
            else { return false; }     
        }

        // As you complete each task make sure you test your code carefully
        // Choose some combination of manual testing, Debug.Assert and unit tests

        // Task One DONE        
        // The bank account should have a balance property        
        // It should have a constructor that sets the initial balance (default zero) and the opening date (default today)
        // It should have methods to deposit and withdraw/make payments from the account. 

        // Task Two DONE
        // Give the option to set an overdraft limit
        // Do not allow a withdrawal/payment if the overdraft limit is exceeded. You could return false or throw an exception.

        // Task Three
        // Create a new class called AccountTransaction.
        // It could contain properties such as
        // date, amount, category, counterparty, transactionType, description (optional)
        // e.g 26/09/2022 16:45, -300, Groceries, Waitrose, Card, Weekly shop
        //     27/09/2022 17:40, 200, Gift, Bob Smith, Cheque, Birthday present
        // You might wish to use enums for category and transactionType
        // Amend your bank account to contain a list of transactions
        // The methods for  deposit and withdraw/make payments should be amended to add transactions

        // Task Four
        // Now add some new methods to your account
        // - See what the balance was at a previous date
        // - See how much money was spent in a given time period
        // - See how much money was spent in different categories

        // Extension
        // Work out how much interest is payable on your account
        // For the moment make up the interest rates, though later we could look at loading them from a website
        // The interest should be added as transactions to your account





    }
}
