using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SafariPark
{
    class LaserGun : Weapon
    {
        public LaserGun(string name) : base(name)
        {

        }

        public override string Shoot()
        {
            return $"Zing {base.Shoot()}";
        }

    }
}
