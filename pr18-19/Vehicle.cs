using System;
using System.Runtime.Serialization;

namespace ConsoleApp2
{
    [DataContract]
    [KnownType(typeof(Car))]
    [KnownType(typeof(Motorcycle))]
    [KnownType(typeof(Truck))]
    public abstract class Vehicle : IComparable<Vehicle>
    {
        [DataMember]
        protected string brand;

        [DataMember]
        protected string carNumber;

        [DataMember]
        protected int speed;

        [DataMember]
        protected int liftingCapacity;

        public Vehicle() { }

        public Vehicle(string brand, string carNumber, int speed, int liftingCapacity)
        {
            this.brand = brand;
            this.carNumber = carNumber;
            this.speed = speed;
            this.liftingCapacity = liftingCapacity;
        }

        public abstract int LiftingCapacity { get; }

        public int CompareTo(Vehicle other)
        {
            if (other == null) return 1;
            return LiftingCapacity.CompareTo(other.LiftingCapacity);
        }

        public override string ToString()
        {
            return $"Brand: {brand}, Car Number: {carNumber}, Speed: {speed}, Lifting Capacity: {liftingCapacity}";
        }
    }
}
