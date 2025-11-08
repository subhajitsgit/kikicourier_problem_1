using KikiCourier.Domain;
using KikiCourier.Services;
using KikiCourier.Services.Interfaces;
using KikiCourier.Services.Offers;
using Microsoft.Extensions.DependencyInjection;

// === Dependency Injection setup ===
var services = new ServiceCollection()
    .AddSingleton<ICostCalculator, CostCalculator>()
    .AddSingleton<IOffer, Ofro01>()
    .AddSingleton<IOffer, Ofro02>()
    .AddSingleton<IOffer, Ofro03>()
    .AddSingleton<OfferEngine>()
    .BuildServiceProvider();

var calc = services.GetRequiredService<ICostCalculator>();
var engine = services.GetRequiredService<OfferEngine>();

// === Step 1: Read input in sample format ===
Console.WriteLine("Enter input in format:");
Console.WriteLine("base_delivery_cost no_of_packages");
Console.WriteLine("pkg_id pkg_weight_in_kg distance_in_km offer_code");
Console.WriteLine();

Console.Write("Input: ");
string[] header = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries) ?? Array.Empty<string>();
if (header.Length < 2)
{
    Console.WriteLine("Invalid input. Please provide base cost and number of packages.");
    return;
}

decimal baseCost = decimal.Parse(header[0]);
int packageCount = int.Parse(header[1]);

var packages = new List<Package>();

for (int i = 0; i < packageCount; i++)
{
    string? line = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(line))
    {
        Console.WriteLine("Invalid package input.");
        return;
    }

    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length < 4)
    {
        Console.WriteLine("Invalid package input format. Expected: pkg_id weight distance offer_code");
        return;
    }

    string pkgId = parts[0];
    decimal weight = decimal.Parse(parts[1]);
    decimal distance = decimal.Parse(parts[2]);
    string offerCode = parts[3];

    packages.Add(new Package(pkgId, weight, distance, offerCode));
}

// === Step 2: Process each package ===
Console.WriteLine();
Console.WriteLine("Output:");

foreach (var pkg in packages)
{
    var deliveryCost = calc.ComputeBaseCharge(baseCost, pkg);
    var discount = engine.ComputeDiscount(deliveryCost, pkg);
    var total = deliveryCost - discount;

    Console.WriteLine($"{pkg.Id} {Fmt(discount)} {Fmt(total)}");
}

// === Helper function ===
static string Fmt(decimal v)
{
    // if decimal ends with .00, print integer
    if (v % 1 == 0)
        return ((int)v).ToString();
    return v.ToString("0.##");
}
