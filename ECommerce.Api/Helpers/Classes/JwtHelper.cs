using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Helpers.Classes
{
    public class JwtHelper
    {
        public string Key { get; set; }
        public int ExpireTimeInMinutes { get; set; }
    }

}
