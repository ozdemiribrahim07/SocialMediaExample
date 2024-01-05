using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; } // Hedef Kitle
        public string Issuer { get; set; } //tokenin hangi sistem veya uygulama tarafından oluşturlduğunu gösterir.
        public int AccessTokenExpiration { get; set; } //token skt 
        public string SecurityKey { get; set; }//imzalama

    }
}
