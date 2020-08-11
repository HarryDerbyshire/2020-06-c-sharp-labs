using System;
using System.Collections.Generic;
using System.Text;
using ClassApp;

namespace SafariPark
{
    public class Hunter : Person, IShootable
    {
        public IShootable Shooter { get; set; }

        public Hunter(string fName, string lName, IShootable aShooter) : base(fName, lName)
        {
            Shooter = aShooter;
        }
        public Hunter()
        {

        }
        
        public string Shoot()
        {
            return $"{GetFullName()}: {Shooter.Shoot()}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} Shooter: {Shooter}";
        }

    }
    public class MonsterHunter : Hunter
    {
        
        public MonsterHunter(string fName, string lName, string camera, IShootable aShooter) : base(fName, lName, aShooter)
        {
            Shooter = aShooter;
        }

        public string Attack()
        {
            return $"{GetFullName()} has attacked you with {Shooter}";
        }

        public override string ToString()
        {
            return $"{base.ToString()} Weapon: {Shooter}";
        }
    }

}
