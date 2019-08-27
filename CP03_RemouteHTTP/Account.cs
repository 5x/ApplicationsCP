using System;
using Server.Bank;

namespace CP03_RemoteHTTPServer {

    public class BankAccount : MarshalByRefObject, IAccount {
        private readonly Account account;

        public BankAccount() {
            this.account = new Account("[BankCustomer]");
        }

        public string Owner {
            get { return this.account.Owner; }
        }

        public decimal Balance {
            get { return this.account.Balance; }
        }

        public void Deposite(decimal amount) {
            this.account.Deposite(amount);

            // For demonstration purposes only.
            this.ShowEnvInfo();
        }

        public void Withdraw(decimal amount) {
            this.account.Withdraw(amount);
        }

        public bool IsOverdrawn() {
            return this.account.IsOverdrawn();
        }

        // For demonstration purposes only.
        private void ShowEnvInfo() {
            string serverDomainName = AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine("Server: AppDomain = \"{0}\".{1}",
                serverDomainName, Environment.NewLine);
        }
    }

}