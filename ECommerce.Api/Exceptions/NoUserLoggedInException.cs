using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class NoUserLoggedInException : Exception
    {
        public NoUserLoggedInException() : base("No User Logged in the system") { }
    }
}
