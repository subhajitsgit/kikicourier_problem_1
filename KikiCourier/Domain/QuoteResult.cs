using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Domain
{
    public sealed record QuoteResult(
    string PackageId,
    decimal DiscountAmount,
    decimal TotalCost
    );
}
