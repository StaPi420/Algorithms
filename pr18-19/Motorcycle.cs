using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Motorcycle : Vehicle
    {
        private bool hasSidecar = false;
        public Motorcycle(String brand, String carNumber, int speed, int liftingCapacity, bool hasSidecar) : base(brand, carNumber, speed, liftingCapacity)
        {
            this.hasSidecar = hasSidecar;
        }
        public override int LiftingCapacity
        {
            get
            {
                return hasSidecar ? liftingCapacity : 0;
            }
        }
    }
}