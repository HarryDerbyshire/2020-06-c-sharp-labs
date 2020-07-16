using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SafariPark
{
    public class Vehicle
    {
        private int _capacity;
        private int _numPassengers;
        private int _speed;

        public int NumPassengers
        {
            get { return _numPassengers; }
            set { if (value <= _capacity) _numPassengers = value; }
        }
        public int Position { get; protected set; }

        public Vehicle()
        {
            _speed = 10;
        }

        public Vehicle(int capacity, int speed = 10)
        {
            _capacity = capacity;
            _speed = speed;
        }

        public virtual string Move()
        {
            Position += _speed;
            return "Moving along";
        }

        public virtual string Move(int times)
        {
            Position += _speed * times;
            return $"Moving along {times} times";
            
        }

        public override string ToString()
        {
            return $"{base.ToString()} capacity: {_capacity} passengers: {NumPassengers} speed: {_speed} position: {Position}";
        }

    }

    public class Airplane : Vehicle
    {
        private string _airline;
        private int _altitude;

        public Airplane( int capacity, int speed, string airline, int altitude) : base(capacity, speed)
        {
            _airline = airline;
            _altitude = altitude;
        }

        public void Ascend(int distance)
        {
            _altitude += distance;
        }

        public void Descend(int distance)
        {
            _altitude -= distance;
        }

        public override string Move()
        {
            return $"{base.Move()} at an altitude: {_altitude} metres";
        }

        public override string Move(int times)
        {
            return $"{base.Move(times)} at an altitude {_altitude} metres";
        }

        public override string ToString()
        {
            return $"{base.ToString()} altitude: {_altitude}";
        }
    }
}
