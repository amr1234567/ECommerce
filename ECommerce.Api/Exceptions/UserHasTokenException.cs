using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class UserHasTokenException : Exception
    {
        public UserHasTokenException() : base("User has token already") { }
    }
}
