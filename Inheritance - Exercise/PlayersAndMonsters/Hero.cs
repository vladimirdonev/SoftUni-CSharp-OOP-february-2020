using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string username { get; set; }
        private int level { get; set; }
        public Hero(string username,int level)
        {
            this.username = username;
            this.level = level;
        }
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
