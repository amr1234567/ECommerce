using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Exceptions
{
    public class ModelStateNotValidException : Exception
    {
        public ModelStateNotValidException(string endPointName) : base($"Model Passed to end point {endPointName} can't be invalid") { }
    }
}
