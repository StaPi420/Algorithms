using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    abstract public class Vehicle : IComparable<Vehicle>
    {
        protected String brand, carNumber;
        protected int speed, liftingCapacity;
        public Vehicle()
        {

        }
        public Vehicle(Vehicle other)
        {
            this.brand = other.brand;
            this.carNumber = other.carNumber;
            this.speed = other.speed;
            this.liftingCapacity = other.liftingCapacity;
        }
        public Vehicle(String brand, String carNumber, int speed, int liftingCapacity)
        {
            this.brand = brand;
            this.carNumber = carNumber;
            this.speed = speed;
            this.liftingCapacity = liftingCapacity;
        }
        public abstract int LiftingCapacity{
            get;
        }
        abstract public void Show();
        /*{
            Console.WriteLine($"Марка: {brand}\nНомер: {carNumber}\nСкорость: {speed}\nГрузоподъёмность:{liftingCapacity}");
        }*/
        public int CompareTo(Vehicle other)
        {
            if (other == null) return 1;
            return this.LiftingCapacity.CompareTo(other.LiftingCapacity);
        }
    }
}
