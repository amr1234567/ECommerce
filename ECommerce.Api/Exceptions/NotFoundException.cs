using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string objectDetails) : base(objectDetails.Trim() + " can't be found") { }
        public NotFoundException() : base("Element Can't be found") { }
    }
}
