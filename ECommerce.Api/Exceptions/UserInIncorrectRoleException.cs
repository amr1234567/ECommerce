using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class UserInIncorrectRoleException : Exception
    {
        public UserInIncorrectRoleException(string role) : base($"User not an {role}") { }
    }
}
