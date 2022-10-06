using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpObjectIntro.Classes.BankAccount;

namespace CSharpObjectIntro.Tests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]

        public void TestBankBalance()
        {
            var tempBank = new BankAccount(600);
            tempBank.Withdraw(500);
            Assert.AreEqual(tempBank.Balance, 100);

        }
        
    }
}
