using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpObjectIntro.Classes.Diary;
using CSharpObjectIntro.Classes.BankAccount;

namespace CSharpObjectIntro
{
    internal class OOPExercises
    {
        internal static void Run()
        {
            //UseDiary();
            UseBankAccount();
        }

        internal static void UseDiary()
        {
            // Create a new diary 
            Diary diary = new Diary("Alex's Diary");

            // Add some events to your diary
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            DateOnly tomw = new DateOnly(2022, 10, 4);


            diary.AddEvent(today, 3, "eat", "home");
            diary.AddEvent(today, 15, "sleep", "home");

            diary.AddEvent(tomw, 5, "leave for school", "home");

            // Now check how many events you have on a particular day

            int numEvents = diary.CheckDiary(today);
            Console.WriteLine(numEvents);

            // Implement a new method in the Diary class to return the number of morning events on a particular day
            // Call this method

            int numMornings = diary.CheckMorningEvents(today);
            Console.WriteLine(numMornings);
        }

        internal static void UseBankAccount()
        {     
            BankAccount myBank = new BankAccount(100);

            Console.WriteLine(Success(myBank.Withdraw(100)));
            myBank.Deposit(500);
            
            myBank.ChangeOverDraftLimit(-100);

            Console.WriteLine(Success(myBank.Withdraw(1000)));

            myBank.MakeTransaction(DateTime.Now, 200, "grocery", "Waitrose", "Card");

            myBank.ApplyInterest();

            myBank.MakeTransaction(DateTime.Now.AddDays(-1), 200, "games");
            myBank.MakeTransaction(DateTime.Now.AddDays(-2), 300);
            

            Console.WriteLine("Balance yesterday = " + myBank.BalanceAtDate(DateTime.Now.AddDays(-1)) + "\n");
            Console.WriteLine("Money spent between yesterday and tomorrow = " + myBank.MoneyBetween(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1)) + "\n");

            Console.WriteLine("Total transactions by category: ");
            var categMoney = myBank.AllCategoriesMoney();       
            foreach (KeyValuePair<string, decimal> kvp in categMoney)
                Console.WriteLine("{0}:{1}", kvp.Key, kvp.Value);

            /*
            foreach (var transaction in myBank.transactions)
            {
                Console.WriteLine(transaction.Amount);
            }
            */

        }

        static string Success(bool transac)
        {
            return transac ? "can withdraw" : "can't withdraw";
        }
    }
}

