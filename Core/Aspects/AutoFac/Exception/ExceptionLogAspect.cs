using Castle.DynamicProxy;
using Core.CrossCuttingC.Log.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.LogMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.AutoFac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new System.Exception(AspectMessages.WrongLoggerType);
            }
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }


        protected LogExceptionWihtDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();

            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    LogName = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    LogType = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetailException = new LogExceptionWihtDetail
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetailException;

        }



    }
}
