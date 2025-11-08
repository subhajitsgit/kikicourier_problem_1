using KikiCourier.Domain;
using KikiCourier.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services
{
    public sealed class InputParser : IInputParser
    {
        public (decimal BaseCost, int Count, List<Package> Packages) ParseFromConsole()
        {
            // header: base_delivery_cost no_of_packages
            var header = ReadNonEmptyLine();
            var hparts = header.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (hparts.Length < 2)
                throw new ArgumentException("Header must be: base_delivery_cost no_of_packages");

            if (!decimal.TryParse(hparts[0], out var baseCost))
                throw new ArgumentException("Invalid base_delivery_cost");

            if (!int.TryParse(hparts[1], out var count) || count < 0)
                throw new ArgumentException("Invalid no_of_packages");

            var list = new List<Package>(count);
            for (int i = 0; i < count; i++)
            {
                var line = ReadNonEmptyLine();
                var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4)
                    throw new ArgumentException("Each package line: pkg_id weight_kg distance_km offer_code");

                var id = parts[0];
                if (!decimal.TryParse(parts[1], out var weight))
                    throw new ArgumentException($"Invalid weight for {id}");
                if (!decimal.TryParse(parts[2], out var distance))
                    throw new ArgumentException($"Invalid distance for {id}");
                var code = parts[3];

                list.Add(new Package(id, weight, distance, code));
            }

            return (baseCost, count, list);
        }

        private static string ReadNonEmptyLine()
        {
            string? s;
            do { s = Console.ReadLine(); }
            while (s != null && string.IsNullOrWhiteSpace(s));
            return s ?? string.Empty;
        }
    }

}
