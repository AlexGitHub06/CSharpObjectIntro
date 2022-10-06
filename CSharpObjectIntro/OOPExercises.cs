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
            BankAccount myBank = new BankAccount(500);
            myBank.Deposit(500);
            myBank.OverDraft = -100;
            bool wP = myBank.Withdraw(1000);
            Console.WriteLine(wP ? "can withdraw" : "can't withdraw");
        }
    }
}

