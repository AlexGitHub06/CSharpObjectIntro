using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpObjectIntro.Classes.BankAccount
{
    public class AccountTransaction
    {
        public AccountTransaction(DateOnly date, decimal amount, string category = "", string counterparty = "", string transactionType = "", string description = "")
        {
            Date = date;
            Amount = amount;
            Category = category;
            Counterparty = counterparty;
            TransactionType = transactionType;
            Description = description;
        }

        public DateOnly Date { get; private set; }
        public decimal Amount { get; private set; }
        public string Category { get; private set; }
        public string Counterparty { get; private set; }
        public string TransactionType { get; private set; }
        public string Description { get; private set; }

    }
}
