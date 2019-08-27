using System;
using System.Reflection;

namespace CP08_MetaAttributes {

    class MetaExplorer {
        public static string[] GetModules(Assembly assembly) {
            return Array.ConvertAll(assembly.GetModules(), x => x.Name);
        }

        public static string[] GetTypes(Module module) {
            return Array.ConvertAll(module.GetTypes(), x => x.Name);
        }

        public static string[] GetFields(Type type) {
            return Array.ConvertAll(type.GetFields(), x => x.Name);
        }

        public static string[] GetProperties(Type type) {
            return Array.ConvertAll(type.GetProperties(), x => x.Name);
        }

        public static string[] GetMethods(Type type) {
            return Array.ConvertAll(type.GetMethods(), x => x.ToString());
        }

        public static string[] GetConstructors(Type type) {
            return Array.ConvertAll(type.GetConstructors(), x => x.ToString());
        }

        public static string[] GetEvents(Type type) {
            return Array.ConvertAll(type.GetEvents(), x => x.ToString());
        }
    }

}