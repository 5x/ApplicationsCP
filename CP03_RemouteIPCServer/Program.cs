using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
// Import common code base parts(like IAccount, and BankAccount).
using CP03_RemoteHTTPServer;

namespace CP03_RemoteIPCServer {

    internal class Program {
        public static void Main() {
            const string portName = "localhost:9090";
            IpcChannel channel = new IpcChannel(portName);
            const bool ensureSecurity = false;
            ChannelServices.RegisterChannel(channel, ensureSecurity);

            Type tAccount = typeof(BankAccount);
            const string accountUri = "Account.rem";

            RemotingConfiguration.RegisterWellKnownServiceType(
                tAccount, accountUri, WellKnownObjectMode.Singleton);

            // Show the URIs associated with the channel.
            ChannelDataStore channelData = (ChannelDataStore) channel.ChannelData;
            foreach (string uri in channelData.ChannelUris) {
                Console.WriteLine("The channel URI is {0}.", uri);
            }

            string[] urls = channel.GetUrlsForUri("Account.rem");
            if (urls != null && urls.Length > 0) {
                string objectUrl = urls[0];
                Console.WriteLine("The Account object URL is {0}.", objectUrl);
            }
            
            Console.ReadLine();
            Console.WriteLine("Server stop loop.");
        }
    }

}