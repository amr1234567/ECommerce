using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(0, 100)]
        public Nullable<double> DiscountPercentage { get; set; } = 0;
        [AllowNull]
        public Nullable<DateTime> FinalDate { get; set; }
        [AllowNull]
        public Nullable<DateTime> FirstDate { get; set; }
    }
}
