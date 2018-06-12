using System;
using System.Collections.Generic;
using System.Text;

namespace TestLab1
{
    public class Account
    {
        public Account(double initialBalance, double rate)
        {
            if (initialBalance < 0 || rate < 0)
            {
                throw new Exception("Kan inte ta emot ett negativt värde");
            }

            this.Balance = initialBalance;
            this.Rate = rate;
        }

        public double Balance { get; private set; }

        public double Rate { get; private set; }

        public void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Kan inte sätta in ett negativt värde. Gör ett uttag istället");
            }
            else if (double.MaxValue - amount < this.Balance)
            {
                throw new Exception("För stor insättning");
            }
            this.Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Kan inte ta ut ett negativt värde. Gör en insättning istället");
            }
            else if (amount > this.Balance)
            {
                throw new Exception("Du har inte tillräckligt med pengar på kontot");
            }
            this.Balance -= amount;
        }

        public bool Transfer(Account target, double amount)
        {
            if (target == null || target == this)
            {
                return false;
            }
            else if (amount > this.Balance || amount < 0)
            {
                return false;
            }
            else if (this.Balance - amount - target.Balance < 0)
            {
                return false;
            }
            target.Balance += amount;
            this.Balance -= amount;
            return true;
        }

        public double CalculateInterest()
        {
            double rent = this.Balance * (this.Rate / 100);
            if (double.MaxValue - this.Balance - rent < 0)
            {
                throw new Exception("Räntan blev för stor");
            }
            this.Balance += rent;

            return rent;
        }
    }
}
