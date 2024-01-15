using System;

namespace TruckCentreWF.Model.Dto
{
    public class Part
    {
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public Part()
        {
            // Default constructor
        }

        public Part(int serialNumber, string name, decimal unitPrice)
        {
            SerialNumber = serialNumber;
            Name = name;
            UnitPrice = unitPrice;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Part other = (Part)obj;
            return SerialNumber == other.SerialNumber;
        }

        public override int GetHashCode()
        {
            return SerialNumber.GetHashCode();
        }
    }
}

