using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Car : Vehicle
    {
        public Car(String brand, String carNumber, int speed, int liftingCapacity) : base(brand, carNumber, speed, liftingCapacity){}
        public override int LiftingCapacity
        {
            get
            {
                return liftingCapacity;
            }
        }
    }
}