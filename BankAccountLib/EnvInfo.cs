using System;
using System.IO;
using System.Reflection;

namespace Server.Bank {

    public class EnvInfo {
        public static string GetDomainName() {
            return AppDomain.CurrentDomain.FriendlyName;
        }

        public static string GetAssemblyPath(Assembly assembly) {
            string location = assembly.Location;

            if (String.IsNullOrEmpty(location)) {
                // Loaded from CodeBase or by dynamic assembly(Reflection.Emmit)
                return String.Empty;
            }

            return Path.GetDirectoryName(location);
        }
    }

}