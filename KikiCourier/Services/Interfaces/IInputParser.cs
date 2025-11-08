using KikiCourier.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KikiCourier.Services.Interfaces
{
    public interface IInputParser
    {
        // Reads console input in the specified format and returns parsed data
        (decimal BaseCost, int Count, List<Package> Packages) ParseFromConsole();
    }
}
