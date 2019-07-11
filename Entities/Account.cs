using Course.Entities.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double balance, double withdrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= WithdrawLimit)
            {
                if (amount <= Balance)
                {
                    Balance -= amount;
                }
                else
                {
                    throw new DomainException("Not enough balance");
                }
            }
            else
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
        }
    }
}
