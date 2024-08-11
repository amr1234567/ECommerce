using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class NotValidDateException : Exception
    {
        public NotValidDateException(string message) : base(message)
        {
        }

        public static void ThrowIfDateInValid(DateTime date)
        {
            if (date < DateTime.UtcNow)
                throw new NotValidDateException($"{date} is in the past");
        }
        public static void ThrowIfDateInValid(DateTime? date)
        {
            if (date is null || date < DateTime.UtcNow)
                throw new NotValidDateException($"{date} is in the past");
        }
    }
}
