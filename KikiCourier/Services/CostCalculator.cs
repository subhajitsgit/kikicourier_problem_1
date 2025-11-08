using KikiCourier.Domain;
using KikiCourier.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services
{
    public sealed class CostCalculator : ICostCalculator
    {
        public decimal ComputeBaseCharge(decimal baseDeliveryCost, Package pkg)
            => baseDeliveryCost + (pkg.WeightKg * 10m) + (pkg.DistanceKm * 5m);
    }

}
