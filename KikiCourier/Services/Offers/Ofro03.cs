using KikiCourier.Domain;
using KikiCourier.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services.Offers
{
    public sealed class Ofro03 : IOffer
    {
        public string Code => "OFR003";
        public decimal DiscountRate => 0.05m;

        public bool IsEligible(Package pkg)
            => pkg.DistanceKm >= 50m && pkg.DistanceKm <= 250m
            && pkg.WeightKg >= 10m && pkg.WeightKg <= 150m;
    }

}
