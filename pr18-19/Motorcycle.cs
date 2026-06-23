using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace ConsoleApp2
{
    [DataContract]
    class Motorcycle : Vehicle
    {
        [DataMember]
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
        public override string ToString()
        {
            return $"Motorcycle\nBrand: {brand}\nCar Number: {carNumber}\nSpeed: {speed}\nLifting Capacity: {liftingCapacity}\nHas Sidecar: {hasSidecar}";
        }
    }
}
