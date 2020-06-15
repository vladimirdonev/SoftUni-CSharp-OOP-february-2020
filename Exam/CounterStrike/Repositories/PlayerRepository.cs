using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>, IEnumerable<IPlayer>
    {
        private ICollection<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => (IReadOnlyCollection<IPlayer>)this.models;

        public void Add(IPlayer model)
        {
            if(model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            this.models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            var player = this.Models.FirstOrDefault(x => x.Username == name);
            return player;
        }

        public IEnumerator<IPlayer> GetEnumerator()
        {
            foreach (var player in this.Models)
            {
                yield return player;
            }
        }

        public bool Remove(IPlayer model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
