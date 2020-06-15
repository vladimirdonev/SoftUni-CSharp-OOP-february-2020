using System;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                this.name = value;
            }
        }

        public int BulletsCount 
        {
            get { return this.bulletsCount; }
            protected set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }
                this.bulletsCount = value;
            }
        }

        public virtual int Fire()
        {
            var bullets = 0;
            if(GetType().Name == "Rifle")
            {
                bullets = 10;
            }
            else if (GetType().Name == "Pistol")
            {
                bullets = 1;
            }
            return bullets;
        }
    }
}
