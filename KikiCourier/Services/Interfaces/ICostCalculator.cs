using KikiCourier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services.Interfaces
{
    public interface ICostCalculator
    {
        // Base + (weight * 10) + (distance * 5)
        decimal ComputeBaseCharge(decimal baseDeliveryCost, Package pkg);
    }
}
