using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if(type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else if(type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            this.guns.Add(gun);
            return string.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer player = null;
            IGun gun = null;
            if(type == "Terrorist")
            {
                gun = this.guns.FindByName(gunName);
                if(gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                player = new Terrorist(username, health, armor, gun);
            }
            else if(type == "CounterTerrorist")
            {
                gun = this.guns.FindByName(gunName);
                if (gun == null)
                {
                    throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
                }
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            players.Add(player);
            return string.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in this.players.Models.OrderBy(x => x.GetType().Name).ThenByDescending(x => x.Health).ThenBy(x => x.Username))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartGame()
        {
            var playersingame = (ICollection<IPlayer>)this.players.Models;
            var win = map.Start(playersingame);
            this.players = new PlayerRepository();
            foreach (var player in playersingame)
            {
                this.players.Add(player);
            }
            return win;
        }
    }
}
