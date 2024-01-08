using Castle.DynamicProxy;
using Core.CrossCuttingC.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.AutoFac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validationType;

        public ValidationAspect(Type validationType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validationType))
            {
                throw new System.Exception("Doğrulama sınıfı değildir.");
            }


            _validationType = validationType;
        }


        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validationType);
            var entityType = _validationType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }

        }


    }
}
