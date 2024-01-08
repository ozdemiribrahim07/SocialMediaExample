using Castle.DynamicProxy;
using Core.Aspects.AutoFac.Exception;
using Core.Aspects.AutoFac.Performance;
using Core.CrossCuttingC.Log.Log4Net.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {

            var classAttribute = type.GetCustomAttributes<MethodInterceptorsBaseAttribute>(true).ToList();

            var methodAttribute = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptorsBaseAttribute>(true);

            classAttribute.AddRange(methodAttribute);
            classAttribute.Add(new PerformanceAspect(0));
            classAttribute.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttribute.OrderBy(x => x.Priority).ToArray();

        }
    }
}
