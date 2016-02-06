using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        // unit test code
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert
            //The method is rather simple.
            //We set up a new BankAccount object with a beginning balance 
            //and then withdraw a valid amount.We use the Microsoft unit test 
            //framework for managed code AreEqual method to verify that the 
            //ending balance is what we expect.
            //A test method must meet the following requirements:
            //The method must be decorated with the[TestMethod] attribute.
            //The method must return void.
            //The method cannot have parameters.

          double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}
