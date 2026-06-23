using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ConsoleApp2
{
    [DataContract]
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
        public override string ToString()
        {
            return $"Car\nBrand: {brand}\nCar Number: {carNumber}\nSpeed: {speed}\nLifting Capacity: {liftingCapacity}";
        }
    }
}
