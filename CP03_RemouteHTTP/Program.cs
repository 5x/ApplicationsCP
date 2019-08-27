using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;

namespace CP03_RemoteHTTPServer {

    internal class Program {
        public static void Main() {
            const int port = 8080;
            HttpChannel channel = new HttpChannel(port);
            const bool ensureSecurity = false;
            ChannelServices.RegisterChannel(channel, ensureSecurity);

            Type tAccount = typeof(BankAccount);
            const string accountUri = "Account";

            RemotingConfiguration.RegisterWellKnownServiceType(
                tAccount, accountUri, WellKnownObjectMode.Singleton);

            Console.WriteLine("Server is listening on port: {0}", port);
            Console.ReadLine();
            Console.WriteLine("Server stop loop.");
        }
    }

}