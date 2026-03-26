using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Car : Vehicle
    {
        public override void Show()
        {
            Console.WriteLine($"Марка: {brand}\nНомер: {carNumber}\nСкорость: {speed}\nГрузоподъёмность:{liftingCapacity}");
        }
        public override int LiftingCapacity
        {
            get
            {
                return liftingCapacity;
            }
        }
    }
}
