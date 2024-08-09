using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class ParameterIsNullOrEmptyException : Exception
    {
        public ParameterIsNullOrEmptyException(string message) : base($"{message.Trim()} can't be null or empty") { }
    }
}
