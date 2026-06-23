using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApp2
{
    [DataContract]
    public class Truck : Vehicle
    {
        [DataMember]
        private bool hasTrailer = false;
        public Truck(String brand, String carNumber, int speed, int liftingCapacity, bool hasTrailer) : base(brand, carNumber, speed, liftingCapacity)
        {
            this.hasTrailer = hasTrailer;
        }
        public override int LiftingCapacity
        {
            get
            {
                if (hasTrailer) return 2 * liftingCapacity;
                else return liftingCapacity;
            }
        }
        public bool HasTrailer
        {
            get
            {
                return hasTrailer;
            }
            set
            {
                hasTrailer = value;
            }
        }
        public override string ToString()
        {
            return $"Truck\nBrand: {brand}\nCar Number: {carNumber}\nSpeed: {speed}\nLifting Capacity: {liftingCapacity}\nHas Trailer: {hasTrailer}";
        }
    }
}
