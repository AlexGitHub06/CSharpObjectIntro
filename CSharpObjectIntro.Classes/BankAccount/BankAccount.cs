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
            _initialBalance = balance;
            OpeningDate = DateTime.Today;
            OverDraft = 0;
            
        }

        //Fields
        public List<AccountTransaction> transactions = new List<AccountTransaction>(); //make private
        private decimal _initialBalance;
        private decimal _interest = (decimal)1/100; // % divided by 100
        
        //Properties
        public decimal Balance{ get; private set; } 
        public DateTime OpeningDate { get; private set; }
        public decimal OverDraft { get; private set;}

        public void Deposit(decimal money)
        {
            Balance += money;
            var myTransaction = new AccountTransaction(DateOnly.FromDateTime(DateTime.Now), money);
            transactions.Add(myTransaction);
            
        }

        public bool Withdraw(decimal money)
        {

            if (Balance - money > OverDraft) 
            { 
                Balance -= money;
                var myTransaction = new AccountTransaction(DateOnly.FromDateTime(DateTime.Now), -money);
                transactions.Add(myTransaction);
                return true; 
            }

            else { return false; }     
        }


        public bool MakeTransaction(DateTime date, decimal amount, string category = "", string counterparty = "", string transactionType = "", string description = "")
        {
            var myTransaction = new AccountTransaction(DateOnly.FromDateTime(date), amount, category, counterparty, transactionType, description);
            if (Balance - myTransaction.Amount > OverDraft)
            {
                Balance += amount;
                transactions.Add(myTransaction);
                return true;
            }
            else { return false; }
        }

        public bool ChangeOverDraftLimit(decimal value)
        {
            if (Balance > value) { OverDraft = value; return true; }
            else { return false; }

        }

        public decimal BalanceAtDate (DateTime date)
        {
            decimal sumBefore = transactions.Sum(d =>
            {
                if (d.Date <= DateOnly.FromDateTime(date.Date))
                {
                    return d.Amount;
                }
                return 0;
            });

            return _initialBalance + sumBefore;
        }

        public decimal MoneyBetween(DateTime dateStart, DateTime dateEnd)
        {
            decimal sumBetween = transactions.Sum(d =>
            {
                if (d.Date >= DateOnly.FromDateTime(dateStart.Date) && d.Date <= DateOnly.FromDateTime(dateEnd.Date))
                {
                    return d.Amount;
                }
                return 0;
            });

            return sumBetween;
        }

        public IDictionary<string,decimal> AllCategoriesMoney()
        {
            IDictionary<string, decimal> transacDic = new Dictionary<string, decimal>();

            foreach (var transac in transactions)
            {
                if (transacDic.ContainsKey(transac.Category))
                {
                    transacDic[transac.Category] += transac.Amount;
                }

                else if (transac.Category == "" && transacDic.ContainsKey("Unnamed"))
                {
                    transacDic["Unnamed"] += transac.Amount;
                }

                else
                {
                    transacDic[transac.Category == "" ? "Unnamed" : transac.Category] = transac.Amount;
                }
            }

            return transacDic;
        }

        public void ApplyInterest()
        {
            decimal absoluteInterest = Balance * _interest;
            MakeTransaction(DateTime.Now, absoluteInterest, "interest");
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

        // Task Three DONE
        // Create a new class called AccountTransaction.
        // It could contain properties such as
        // date, amount, category, counterparty, transactionType, description (optional)
        // e.g 26/09/2022 16:45, -300, Groceries, Waitrose, Card, Weekly shop
        //     27/09/2022 17:40, 200, Gift, Bob Smith, Cheque, Birthday present
        // You might wish to use enums for category and transactionType
        // Amend your bank account to contain a list of transactions
        // The methods for  deposit and withdraw/make payments should be amended to add transactions

        // Task Four DONE
        // Now add some new methods to your account
        // - See what the balance was at a previous date
        // - See how much money was spent in a given time period
        // - See how much money was spent in different categories

        // Extension DONE
        // Work out how much interest is payable on your account
        // For the moment make up the interest rates, though later we could look at loading them from a website
        // The interest should be added as transactions to your account





    }
}
