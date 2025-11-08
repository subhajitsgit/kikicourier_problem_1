using KikiCourier.Domain;
using KikiCourier.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services.Offers
{
    public sealed class Ofro01 : IOffer
    {
        public string Code => "OFR001";
        public decimal DiscountRate => 0.10m;

        public bool IsEligible(Package pkg)
            => pkg.DistanceKm < 200m && pkg.WeightKg >= 70m && pkg.WeightKg <= 200m;
    }

}
