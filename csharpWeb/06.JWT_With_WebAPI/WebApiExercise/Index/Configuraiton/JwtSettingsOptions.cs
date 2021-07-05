using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Index.Configuraiton
{
    public class JwtSettingsOptions
    {
        public const string JwtSettings = "JwtSettings";

        public string Secret { get; set; }
    }
}
