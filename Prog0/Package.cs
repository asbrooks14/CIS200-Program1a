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
    public abstract class Package : Parcel
    {
        //backing fields
        private double _length, // package length in inches
                       _width, // package width in inches
                       _height,  // package height in inches
                       _weight;  // package weight in pounds

        // constructor
        // precondition: the length, width, height and weight of package are > 0
        // postcondition: The package is created with the specified values for
        //                origin address, destination address, length, width, height and weight
        public Package(Address originAddress, Address destAddress, 
            double length, double width, double height, double weight) : base(originAddress, destAddress)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        // properties start
        protected double Length
        {
            // precondition: none
            // postcondition: package length is returned
            get
            {
                return Length;
            }
            // precondition: value is >0
            // postcondition: length value has been set
            set
            {
                if (value > 0)
                    _length = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Length)}", value,
                        $"{nameof(Length)} must be > 0");
            }
        }

        protected double Width
        {
            // precondition: none
            // postcondition: package width is returned
            get
            {
                return Width;
            }
            // precondition: value is >0
            // postcondition: width value has been set
            set
            {
                if (value > 0)
                    _width = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Width)}", value,
                        $"{nameof(Width)} must be > 0");
            }
        }

        protected double Height
        {
            // precondition: none
            // postcondition: package height is returned
            get
            {
                return Height;
            }
            // precondition: value is > 0
            // postcondition: height value has been set
            set
            {
                if (value > 0)
                    _height = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Height)}", value,
                        $"{nameof(Height)} must be > 0");
            }
        }

        protected double Weight
        {
            // precondition: none
            // postcondition: package weight is returned
            get
            {
                return Weight;
            }
            // precondition: value is > 0
            // postcondition: weight value has been set
            set
            {
                if (value > 0)
                    _weight = value;
                else
                    throw new ArgumentOutOfRangeException($"{nameof(Weight)}", value,
                        $"{nameof(Weight)} must be > 0");
            }
        }

        // precondition: none
        // postcondition: a string with the package data has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Package{NL}{base.ToString()} {NL}Length: {Length:N1}{NL}Width: {Width:N1}" +
                $"{NL}Height: {Height:N1}{NL}Weight: {Weight:N1}"; 
        }
    }
}
