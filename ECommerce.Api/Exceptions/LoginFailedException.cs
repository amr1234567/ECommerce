using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException() : base("Invalid Credential") { }
    }
}
