using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class DateOutOfRangeException : Exception
    {
        public DateOutOfRangeException(string message) : base(message) { }
        public DateOutOfRangeException() : base("Date is out of limited") { }
    }
}
