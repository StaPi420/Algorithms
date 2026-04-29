using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Truck : Vehicle
    {
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
    }
}