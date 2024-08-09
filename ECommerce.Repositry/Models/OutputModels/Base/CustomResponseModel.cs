using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repositry.Models.OutputModels.Base
{
    public class CustomResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Body { get; set; }
    }
}
