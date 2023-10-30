using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSCOP.Identity.Service.Options
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string ClientAppId { get; set; }
    }
}
