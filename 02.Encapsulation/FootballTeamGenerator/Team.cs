using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private string name;

        public Team(string name)
        {
            Name = name;
            Players = new List<Player>();
        }

        public List<Player> Players { get; set; }

        public string Name
        {
            get => name;
            set
            {
            //    if (String.IsNullOrWhiteSpace(value))
            //    {
            //        throw new ArgumentException("A name should not be empty.");
            //    }
                name = value;
            }
        }

        public double Rating()
        {
            double totalRating = 0;
            if (Players.Count > 0)
            {
                foreach (var player in Players)
                {
                    totalRating += player.OverallStats;
                }
                totalRating /= Players.Count;
            }
            return Math.Round(totalRating);
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = Players.Where(x => x.Name == playerName).FirstOrDefault();

            if (playerToRemove == null)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
            }
            else
            {
                Players.Remove(playerToRemove);
            }
        }

    }
}
