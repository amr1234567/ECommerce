using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class CreationException : Exception
    {
        public CreationException(string obj) : base($"error while try create {obj}, try again later") { }
    }
}
