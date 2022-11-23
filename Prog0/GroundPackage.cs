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
    class GroundPackage : Package
    {
        const int DIVISIOR = 10000; // to get first digit of zip codes
        const double DIMENSION_MULTIPLIER = .15; // cost multiplier for package dimensions
        const double WEIGHT_MULTIPLIER = .07; // cost multiplier for package weight

        int zipDistance; // zip code distance

        // constructor
        // precondition: the length, width, height and weight of package are > 0
        // postcondition: The package is created with the specified values for
        //                origin address, destination address, length, width, height and weight
        public GroundPackage(Address originAddress, Address destAddress,
            double length, double width, double height, double weight) : base(originAddress, destAddress, length, width, height, weight)
        {
            // empty
        }

        private int ZoneDistance
        {
            // precondition: none
            // postcondition: zone distance (distance between origin and destination zip codes) is returned
            get
            {
                
                zipDistance = Math.Abs((OriginAddress.Zip / DIVISIOR) - 
                                       (DestinationAddress.Zip / DIVISIOR));
                return zipDistance;
            }
        }

        // calc cost method for ground package
        // precondition: none
        // postcondition: the ground package cost is returned
        public override decimal CalcCost()
        {
            return (decimal) (DIMENSION_MULTIPLIER * (Length + Width + Height) + WEIGHT_MULTIPLIER * (ZoneDistance + 1) * Weight);
        }

        // precondition:  none
        // postcondition: a string with the ground package data is returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Ground Package{base.ToString()}{NL}Zone Distance: {ZoneDistance:N1}" +
                $"{NL}Ground Package Cost: {CalcCost():C2}";
        }
    }
}
