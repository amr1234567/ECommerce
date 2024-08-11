using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.DataAccess.Plugins.Interfaces;
using Stripe;

namespace ECommerce.DataAccess.Plugins.Services
{
    public class StripeServices : IStripeServices
    {
        public StripeServices()
        {
            var services = new CustomerService();

        }
    }
}
