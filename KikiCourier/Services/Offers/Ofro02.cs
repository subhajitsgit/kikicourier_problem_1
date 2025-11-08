using KikiCourier.Domain;
using KikiCourier.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services.Offers
{
    public sealed class Ofro02 : IOffer
    {
        public string Code => "OFR002";
        public decimal DiscountRate => 0.07m;

        public bool IsEligible(Package pkg)
            => pkg.DistanceKm >= 50m && pkg.DistanceKm <= 150m
            && pkg.WeightKg >= 100m && pkg.WeightKg <= 250m;
    }
}
