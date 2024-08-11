using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class SellerAssignToAnotherCategoryException : Exception
    {
        public SellerAssignToAnotherCategoryException(string sellerId) : base($"seller with id {sellerId} assign to different category")
        {

        }
    }
}
