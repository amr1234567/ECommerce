using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Entities.Application.Contained
{
    [Owned]
    public class PeriodDiscount
    {
        [AllowNull]
        public double DiscountAmount { get; set; } = 0;
        [AllowNull]
        public DateTime FinalDate { get; set; }
        [AllowNull]
        public DateTime FirstDate { get; set; }
    }
}
