using Server.Bank;

namespace CP04_RemoteHTTPClient {

    class AccountProxy : StubbornRemoteProxyInstance<IAccount>, IAccount {
        public AccountProxy(string url) : base(url) {
        }

        public string Owner {
            get { return (string) this.GetProperty("Owner"); }
        }

        public decimal Balance {
            get { return (decimal) this.GetProperty("Balance"); }
        }

        public void Deposite(decimal amount) {
            this.InvokeMethod("Deposite", amount);
        }

        public void Withdraw(decimal amount) {
            this.InvokeMethod("Withdraw", amount);
        }

        public bool IsOverdrawn() {
            return (bool) this.InvokeMethod("IsOverdrawn");
        }
    }

}