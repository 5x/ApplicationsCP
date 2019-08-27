using System;

namespace Server.Bank {

    public class Account : IAccount {
        private const decimal DefaultMinBalanceAmount = 0.0m;

        private decimal balance;

        public Account(string customer)
            : this(customer, 0.0m, Account.DefaultMinBalanceAmount) {
        }

        public Account(string customer, decimal startBalance)
            : this(customer, startBalance, Account.DefaultMinBalanceAmount) {
        }

        public Account(string customer, decimal startBalance,
            decimal minBalanceAmount) {
            this.Owner = customer;
            this.MinBalanceAmount = minBalanceAmount;
            this.Balance = startBalance;
        }

        private decimal MinBalanceAmount { get; set; }

        public string Owner { get; private set; }

        public decimal Balance {
            get { return this.balance; }

            private set {
                if (this.IsBalanceInAmountRange(value)) {
                    this.balance = value;
                } else {
                    throw new ArgumentException(
                        "Balance must be more than minimum balance amount.");
                }
            }
        }

        public void Deposite(decimal amount) {
            if (amount < 0.0m) {
                throw new ArgumentException(
                    "Amount not valid, it must be positive value." +
                    " For subtract the balance use `withdraw` method.");
            }

            this.Balance += amount;
        }

        public void Withdraw(decimal amount) {
            decimal expectedBalanceValue = this.Balance - Math.Abs(amount);

            try {
                this.Balance = expectedBalanceValue;
            } catch (ArgumentException) {
                throw new ArgumentException("Not enough funds.");
            }
        }

        public bool IsOverdrawn() {
            return (this.balance < 0.0m);
        }

        private bool IsBalanceInAmountRange(decimal balanceAmount) {
            return (balanceAmount >= this.MinBalanceAmount);
        }
    }

}