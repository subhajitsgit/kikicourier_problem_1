using KikiCourier.Domain;
using KikiCourier.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services
{
    public sealed class OfferEngine
    {
        private readonly IReadOnlyDictionary<string, IOffer> _offers;

        public OfferEngine(IEnumerable<IOffer> offers)
        {
            _offers = offers.ToDictionary(
                o => o.Code.Trim().ToUpperInvariant(),
                o => o
            );
        }

        public decimal ComputeDiscount(decimal preDiscountCharge, Package pkg)
        {
            if (string.IsNullOrWhiteSpace(pkg.OfferCode)) return 0m;

            var code = pkg.OfferCode.Trim().ToUpperInvariant();
            if (!_offers.TryGetValue(code, out var offer)) return 0m;
            if (!offer.IsEligible(pkg)) return 0m;

            // discount is on the full delivery cost (pre-discount)
            return Math.Round(preDiscountCharge * offer.DiscountRate, 2, MidpointRounding.AwayFromZero);
        }
    }

}
