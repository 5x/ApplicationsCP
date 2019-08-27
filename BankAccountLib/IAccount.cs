namespace Server.Bank {

    public interface IAccount {
        string Owner { get; }
        decimal Balance { get; }
        void Deposite(decimal amount);
        void Withdraw(decimal amount);
        bool IsOverdrawn();
    }

}