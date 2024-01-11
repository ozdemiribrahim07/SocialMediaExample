using BusinessLayer.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BusinessAspects.AutoFac
{
    public class SecuredOperation :MethodInterception
    {
        private string[] _userRoles;
        private IHttpContextAccessor _contextAccessor;

        public SecuredOperation(string roles)
        {
            _userRoles = roles.Split(',');
            _contextAccessor = ServiceTool.serviceProvider.GetService<IHttpContextAccessor>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            var rolesClaims = _contextAccessor.HttpContext.User.ClaimsRoles();

            foreach (var role in _userRoles)
            {
                if (rolesClaims.Contains(role))
                {
                    return;
                }

            }

            throw new Exception(Messages.AccessDenied);
        }



    }
}
