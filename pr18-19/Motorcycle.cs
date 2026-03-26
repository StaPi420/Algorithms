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
        public Motorcycle(String brand, String carNumber, int speed)
        {
            this.brand = brand;
            this.carNumber = carNumber;
            this.speed = speed;
            this.liftingCapacity = 0;
        }
        public Motorcycle(String brand, String carNumber, int speed, int liftingCapacity) : base(brand, carNumber, speed, liftingCapacity)
        {
            hasSidecar = true;
        }
        public override int LiftingCapacity
        {
            get
            {
                return LiftingCapacity;
            }
        }
        public override void Show()
        {
            Console.WriteLine($"Марка: {brand}\nНомер: {carNumber}\nСкорость: {speed}\nГрузоподъёмность: {liftingCapacity}\nЕсть коляска{hasSidecars}");
        }
    }
}
