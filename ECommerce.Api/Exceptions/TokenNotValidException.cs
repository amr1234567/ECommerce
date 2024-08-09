using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class TokenNotValidException : Exception
    {
        public TokenNotValidException() : base("Token not valid for this user") { }
    }
}
