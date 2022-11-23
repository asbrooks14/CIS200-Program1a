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
    public abstract class AirPackage : Package
    {
        const int PACK_HEAVY = 75;  // minimum weight for a heavy package
        const int PACK_LARGE = 100; // minimum total dimensions for a large package
       
        // constructor
        // precondition: the length, width, height and weight of package are > 0
        // postcondition: The package is created with the specified values for
        //                origin address, destination address, length, width, height and weight
        public AirPackage(Address originAddress, Address destAddress,
            double length, double width, double height, double weight) : base(originAddress, destAddress, length, width, height, weight)
        {
            // empty
        }

        // heavy package method
        // precondition: none
        // postcondition: bool IsHeavy wil be true if weight >= 75lbs
        public bool IsHeavy()
        {
            return Weight >= PACK_HEAVY;
        }

        // large package method
        // precondition: none
        // postcondition: bool IsLarge wil be true if package length + width + height >= 100in
        public bool IsLarge()
        {
             return Length + Width + Height >= PACK_LARGE;
        }

        // precondition: none
        // postcondition: a string with the air package data is returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Air Package{base.ToString()}{NL}Heavy Package: {IsHeavy()}" +
                $"{NL}Large Package: {IsLarge()}";
        }
    }
}
