using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Middleware.Exception
{
    public class ErrorDetails
    {
        public string ErrorMessage { get; set; }
        public int CodeStatus { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }


}
