// Program 0
// CIS 200-50
// Fall 2021
// Due: 9/27/2021
// Stduent ID: 5129153

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    public class NextDayAirPackage : AirPackage
    {
        const double DIMENSION_MULTIPLIER2 = .35; // base cost multiplier for package dimensions
        const double WEIGHT_MULTIPLIER = .25; // base cost multiplier for package weight
        const double HEAVY_WEIGHT_MULTIPLIER = .20; // heavy cost multiplier for heavy packages
        const double LARGE_DIMENSION_MULTIPLIER = .22; // large cost multiplier for large packages

        decimal baseCost; // next day air base package cost

        //backing fields
        private decimal _expressFee; // express fee

        // constructor
        // precondition: the length, width, height and weight of package are > 0
        // postcondition: The next day air package is created with the specified values for
        //                origin address, destination address, length, width, height, weight
        //                + the express fee
        public NextDayAirPackage(Address originAddress, Address destAddress,
            double length, double width, double height, double weight, decimal expressFee) : base(originAddress, destAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        // properties start
        public decimal ExpressFee
        {
            // precondition: none
            // postcondition: the air package express fee is returned (varies from store to store)
            get
            {
                return _expressFee;
            }
            // precondition: value is > 0
            // postcondition: express fee is set
            private set
            {
                if (value >= 0)
                    _expressFee = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(ExpressFee)}", value,
                        $"{nameof(ExpressFee)} must be >= 0");
            }

        }

        // calccost override method for next day air
        // precondition: none
        // postcondition: next day air package cost is returned
        public override decimal CalcCost()
        {
            baseCost = (decimal) (DIMENSION_MULTIPLIER2 * (Length + Width + Height) + WEIGHT_MULTIPLIER * Weight) + ExpressFee;

            if (IsHeavy())
            {
                baseCost += (decimal)(HEAVY_WEIGHT_MULTIPLIER * Weight);
            }
            if (IsLarge())
            {
                baseCost += (decimal)(LARGE_DIMENSION_MULTIPLIER * (Length + Width + Height));
            }

            return baseCost;
        }

        // precondition: none
        // postcondition: a string with the next day air package data is returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Next Day Air Package{base.ToString()}{NL}Express Fee: {ExpressFee:C2}";
        }
    }
}
