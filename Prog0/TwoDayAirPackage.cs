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
    public class TwoDayAirPackage : AirPackage
    {
        const double DIMENSION_MULTIPLIER3 = .18; // base cost multiplier for package dimensions
        const double WEIGHT_MULTIPLIER3 = .20; // base cost multiplier for package weight
        const decimal DISCOUNT = .85M; // discount multiplier

        decimal baseCost; // two day air base package cost

        public enum Delivery { Early, Saver} // define delivery enum with values early & saver
        
        // backing field
        protected Delivery _deliveryType; // early or saver delivery

        // constructor
        // precondition: the length, width, height and weight of package are > 0
        // postcondition: The two day air package is created with the specified values for
        //                origin address, destination address, length, width, height, weight
        //                + the delivery type early or saver
        public TwoDayAirPackage(Address originAddress, Address destAddress,
            double length, double width, double height, double weight, Delivery deliveryType) : base(originAddress, destAddress, length, width, height, weight)
        {
            DeliveryType = deliveryType;
        }

        // properties/enum start
        public Delivery DeliveryType
        {
            // precondition: none
            // postcondition: two day air package delivery type is returned
            get
            {
                return _deliveryType;
            }
            // precondition: delivery must is set
            private set
            {
                if (Enum.IsDefined(typeof(Delivery), value))
                {
                    _deliveryType = value;
                }
                    
                else
                {
                    throw new ArgumentOutOfRangeException($"{nameof(DeliveryType)}", value,
                        $"{nameof(DeliveryType)} must be {nameof(Delivery.Early)} or " +
                        $"{nameof(Delivery.Saver)}");
                }
            }
        }

        // calc cost method for 2 day air
        // precondition: none
        // postcondition: two day air package cost is returned (discounted if saver delivery type)
        public override decimal CalcCost()
        {
            baseCost = (decimal)(DIMENSION_MULTIPLIER3 * (Length + Width + Height) + WEIGHT_MULTIPLIER3 * Weight);

            if (DeliveryType == Delivery.Saver)
            {
                baseCost *= DISCOUNT;
            }

            return baseCost;
        }

        // precondition:  none
        // postcondition: A string with the two day air package data is returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Two Day Air Package{base.ToString()}{NL}Delivery Type: {DeliveryType}";
        }
    }
}
