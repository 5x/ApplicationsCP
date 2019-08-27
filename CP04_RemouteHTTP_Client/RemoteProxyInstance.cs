using System;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting;

namespace CP04_RemoteHTTPClient {

    abstract class RemoteProxyInstance<T> {
        private static T instance;

        protected RemoteProxyInstance(string url) {
            if (RemoteProxyInstance<T>.instance == null) {
                RemoteProxyInstance<T>.instance =
                    RemoteProxyInstance<T>.GetProxyInstance(url);
            }
        }

        protected static T GetProxyInstance(string url) {
            Type type = typeof(T);
            return
                (T)
                Activator.GetObject(type, url, WellKnownObjectMode.Singleton);
        }

        protected virtual object InvokeMethod(string methodName,
            params object[] arguments) {
            Type proxyType = typeof(T);
            MethodInfo method = proxyType.GetMethod(methodName);

            if (method == null) {
                throw new MissingMethodException(proxyType.FullName, methodName);
            }

            try {
                return method.Invoke(RemoteProxyInstance<T>.instance, arguments);
            } catch (Exception e) {
                this.ErrorHandler(e);
                throw;
            }
        }

        protected virtual object GetProperty(string propertyName) {
            Type proxyType = typeof(T);
            PropertyInfo property = proxyType.GetProperty(propertyName);

            if (property == null) {
                throw new MissingMemberException(
                    "Object doesn't contain a property definition.");
            }

            try {
                return property.GetValue(RemoteProxyInstance<T>.instance, null);
            } catch (Exception e) {
                this.ErrorHandler(e);
                throw;
            }
        }

        protected virtual void ErrorHandler(Exception e) {
            if (e is TargetInvocationException && e.InnerException != null) {
                e = e.InnerException;
            }

            if (e is WebException) {
                throw new ServiceUnavailableException("Http connection error.",
                    e);
            }

            throw e;
        }
    }

}