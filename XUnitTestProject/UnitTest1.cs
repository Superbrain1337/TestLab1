using System;
using Xunit;
using TestLab1;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        //Account
        [Fact]
        public void Account_InitialBalanceAndRateIsPositive()
        {
            Assert.Equal(500, new Account(500, 5).Balance);
            Assert.Equal(5, new Account(500, 5).Rate);
        }

        [Fact]
        public void Account_InitialBalanceIsNegative()
        {
            Assert.Throws<Exception>(() => new Account(-500, 5));
        }

        [Fact]
        public void Account_RateIsNegative()
        {
            Assert.Throws<Exception>(() => new Account(500, -5));
        }

        //Deposit
        [Fact]
        public void Deposit_PositiveValue()
        {
            Account A = new Account(1000, 5);
            A.Deposit(500);
            Assert.Equal(1500, A.Balance);
        }

        [Fact]
        public void Deposit_NegativeValue()
        {
            Account A = new Account(1000, 5);
            Assert.Throws<Exception>(() => A.Deposit(-500));
        }

        [Fact]
        public void Deposit_ToHighValue()
        {
            Account A = new Account(1000, 5);
            Assert.Throws<Exception>(() => A.Deposit(double.MaxValue));
        }

        //Withdraw
        [Fact]
        public void Withdraw_PositiveValue()
        {
            Account A = new Account(1000, 5);
            A.Withdraw(100);
            Assert.Equal(900, A.Balance);
        }

        [Fact]
        public void Withdraw_NegativeValue()
        {
            Account A = new Account(1000, 5);
            Assert.Throws<Exception>(() => A.Withdraw(-100));
        }

        [Fact]
        public void Withdraw_ToHighValue()
        {
            Account A = new Account(1000, 5);
            Assert.Throws<Exception>(() => A.Withdraw(2000));
        }

        //Transfer

        [Fact]
        public void Transfer_NullObject()
        {
            Account A = new Account(1000, 5);
            Assert.False(A.Transfer(null, 200));
        }

        [Fact]
        public void Transfer_NegativeValue()
        {
            Account A = new Account(1000, 5);
            Account B = new Account(500, 5);
            Assert.False(A.Transfer(B, -200));
        }

        [Fact]
        public void Transfer_MoreThanBalance()
        {
            Account A = new Account(300, 5);
            Account B = new Account(700, 5);
            Assert.False(A.Transfer(B, 500));
        }

        [Fact]
        public void Transfer_ToMuchForTargetBalance()
        {
            Account A = new Account(double.MaxValue, 5);
            Account B = new Account(50000, 5);
            Assert.False(A.Transfer(B, double.MaxValue));
        }

        [Fact]
        public void Transfer_OkeyValue()
        {
            Account A = new Account(1000, 5);
            Account B = new Account(500, 5);
            Assert.True(A.Transfer(B, 200));
            Assert.Equal(800, A.Balance);
            Assert.Equal(700, B.Balance);
        }

        [Fact]
        public void Transfer_SameAccount()
        {
            Account A = new Account(1000, 5);
            Assert.False(A.Transfer(A, 200));
        }

        //CalculateInterest
        [Fact]
        public void CalculateInterest_OkeyValues()
        {
            Account A = new Account(1000, 5);
            Assert.Equal(50, A.CalculateInterest());
        }

        [Fact]
        public void CalculateInterest_DecimalValues()
        {
            Account A = new Account(975.5, 5.5);
            Assert.Equal(53.6525, A.CalculateInterest());
        }

        [Fact]
        public void CalculateInterest_ToHighValues()
        {
            Account A = new Account(double.MaxValue, 5);
            Assert.Throws<Exception>(() => A.CalculateInterest());
        }
    }
}
