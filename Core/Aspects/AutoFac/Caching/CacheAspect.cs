using Castle.DynamicProxy;
using Core.CrossCuttingC.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.AutoFac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 15)
        {
            _duration = duration;
            _cacheManager = ServiceTool.serviceProvider.GetService<ICacheManager>();
        }


        public override void Intercept(IInvocation invocation)
        {
            var name = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var method = invocation.Arguments.ToList();
            var key = $"{name}({string.Join(",", method.Select(x => x?.ToString() ?? "<Null>"))})";

            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
            }

            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }



    }
}
