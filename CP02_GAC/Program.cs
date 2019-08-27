using System;
using System.IO;
using System.Reflection;

namespace CP02_GAC {

    class App {
        public static void Run() {
            const string assemblyName = "BankAccount";
            const string assemblyVersion = "1.0.0.0";
            const string assemblyCulture = "neutral";
            const string assemblyPublicKey = "67a0026160ea5d51";

            string accountAssemblyFullName = String.Format(
                "{0},Version={1},Culture={2},PublicKeyToken={3}",
                assemblyName, assemblyVersion, assemblyCulture,
                assemblyPublicKey);
            Assembly assembly = Assembly.Load(accountAssemblyFullName);

            const string serverNamespace = "Server.Bank";
            Type tAccount = DReflectHelper.GetAssemblyType(assembly,
                serverNamespace, "Account");
            Type tEnvType = DReflectHelper.GetAssemblyType(assembly,
                serverNamespace, "EnvInfo");

            const string customerName = "John Doe";
            object bankAccount = Activator.CreateInstance(tAccount, customerName);

            const int depositeCount = 3;
            decimal depositeAmount = 123;
            for (int i = depositeCount; i > 0; i--) {
                depositeAmount *= i;
                DReflectHelper.InvokeMethod(bankAccount, "Deposite",
                    depositeAmount);

                decimal balance =
                    (decimal) DReflectHelper.GetProperty(bankAccount, "Balance");
                string accountOwner =
                    DReflectHelper.GetProperty(bankAccount, "Owner").ToString();

                Console.WriteLine("Client: {0} deposite: {1}$.", customerName,
                    depositeAmount);
                Console.WriteLine("Server: {0} balance: {1}$", accountOwner,
                    balance);

                string serverDomainName =
                    DReflectHelper.InvokeMethod(tEnvType, "GetDomainName")
                        .ToString();
                Console.WriteLine("Server: AppDomain = {0}{1}", serverDomainName,
                    Environment.NewLine);
            }

            string clientDomainName = AppDomain.CurrentDomain.FriendlyName;
            Console.WriteLine("Client: AppDomain = {0}", clientDomainName);

            bool isGlobalAssembly = assembly.GlobalAssemblyCache;
            Console.WriteLine("Account assembly load from GAC? {0}.",
                isGlobalAssembly ? "Yes" : "No");

            string accountAssemblyPath =
                DReflectHelper.InvokeMethod(
                    tEnvType, "GetAssemblyPath", assembly).ToString();
            Console.WriteLine("Account assembly location: {0}",
                accountAssemblyPath);
        }
    }

    internal class Program {
        static void Main(string[] args) {
            Console.Title = "02.KPP1.2.2 GAC";
            AppDomain.CurrentDomain.AssemblyResolve += Program.FindAssembly;
            App.Run();
            Console.ReadKey();
        }

        private static Assembly FindAssembly(object sender,
            ResolveEventArgs args) {
            string name = new AssemblyName(args.Name).Name;
            string fullName = String.Format("{0}.dll", name);
            string externalPath = Program.GetExternalPath();
            string assemblyPath = Path.Combine(externalPath, fullName);

            if (name.EndsWith(".resources") || !File.Exists(assemblyPath)) {
                return null;
            }

            return Assembly.LoadFrom(assemblyPath);
        }

        private static string GetExternalPath() {
            const string externalFolderName = "ExternalAssemblies";
            string driveLetter = Path.GetPathRoot(Environment.CurrentDirectory);
            return Path.Combine(driveLetter, externalFolderName);
        }
    }

}