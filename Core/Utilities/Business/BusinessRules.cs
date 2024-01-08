using Core.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] results)
        {
            foreach (var result in results)
            {
                if (!result.IsSuccess)
                {
                    return result;
                }
            }
            return null;
        }

    }
}
