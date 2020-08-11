using System;
using System.Collections.Generic;
using System.Text;

namespace SafariPark
{
    public class Weapon : IShootable
    {
        private string _name;

        public Weapon(string name)
        {
            _name = name;
        }

        public virtual string Shoot()
        {
            return $"shooting a {_name}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {_name}";
        }
    }
}
