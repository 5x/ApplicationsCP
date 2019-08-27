using System;

namespace CP04_RemoteHTTPClient {

    class AccountService : RemoteService<AccountProxy> {
        public AccountService(string url)
            : base(new AccountProxy(url)) {
        }

        protected override void NextTick() {
            string promptMsg = "How much money you want to deposit? $";
            decimal depositeAmount = AccountService.PromtDecimalValue(promptMsg);
            this.DepositeToCustomerAccount(depositeAmount);
        }

        protected override void ReportUnavailableService() {
            int failuresCount = this.ProxyInstance.MaxFailuresCount;
            Console.WriteLine("Server don't available {0} times.", failuresCount);
        }

        private void DepositeToCustomerAccount(decimal amount) {
            AccountProxy bankAccount = this.ProxyInstance;
            try {
                bankAccount.Deposite(amount);
            } catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Client: {0} deposite: {1}$.", 
                bankAccount.Owner, amount);
            Console.WriteLine("Server: {0} balance: {1}$.", 
                bankAccount.Owner, bankAccount.Balance);
        }

        private static decimal PromtDecimalValue(string message) {
            Console.Write("> {0}", message);
            string userInput = Console.ReadLine();

            try {
                return Convert.ToDecimal(userInput);
            } catch (FormatException) {
                return 0.0m;
            }
        }
    }

}