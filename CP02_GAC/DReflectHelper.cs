using System;
using System.Reflection;

namespace CP02_GAC {

    public class DReflectHelper {
        public static Type GetAssemblyType(Assembly assembly,
            params string[] typeNameParts) {
            string fullTypeName = String.Join(".", typeNameParts);
            const bool throwOnError = true;

            return assembly.GetType(fullTypeName, throwOnError);
        }

        public static object InvokeMethod(object self, string methodName,
            params object[] arguments) {
            Type clsType = DReflectHelper.GetActualObjectType(self);
            MethodInfo method = clsType.GetMethod(methodName);

            if (method == null) {
                throw new MissingMethodException(clsType.FullName, methodName);
            }

            return method.Invoke(self, arguments);
        }

        public static object GetProperty(object self, string propertyName) {
            Type clsType = self.GetType();
            PropertyInfo property = clsType.GetProperty(propertyName);

            if (property == null) {
                throw new MissingMemberException(
                    "Object doesn't contain a property definition.");
            }

            return property.GetValue(self, null);
        }

        private static Type GetActualObjectType(object self) {
            if ((self as Type) == null) {
                return self.GetType();
            }

            return (Type) self;
        }
    }

}