using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class EmailExistException : Exception
    {
        public EmailExistException(string email) : base($"Email \"{email}\" already exist") { }
    }
}
