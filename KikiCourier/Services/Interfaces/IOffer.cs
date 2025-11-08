using KikiCourier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services.Interfaces
{
    public interface IOffer
    {
        string Code { get; }
        decimal DiscountRate { get; } // e.g., 0.10m = 10%
        bool IsEligible(Package pkg);
    }
}
