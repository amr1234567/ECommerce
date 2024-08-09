using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class DiscountUsedException : Exception
    {
        public DiscountUsedException(string code) : base($"discount with code {code} has already used") { }
    }
}
