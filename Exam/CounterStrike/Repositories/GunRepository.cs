using System;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class GunRepository : IRepository<IGun>
    {
        private ICollection<IGun> models;
        public GunRepository()
        {
            this.models = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => (IReadOnlyCollection<IGun>)this.models;

        public void Add(IGun model)
        {
            if(model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunRepository);
            }
            else
            {
                this.models.Add(model);
            }
        }

        public IGun FindByName(string name)
        {
            var gun = this.models.FirstOrDefault(x => x.Name == name);
            return gun;
        }

        public bool Remove(IGun model)
        {
            if (this.Models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
