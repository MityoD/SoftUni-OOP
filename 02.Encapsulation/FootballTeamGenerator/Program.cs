using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            while (command != "END")
            {
                string teamName = null;
                string[] commandArgs = command.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string action = commandArgs[0];
                if (commandArgs.Length >= 2)
                {
                    teamName = commandArgs[1];
                }
                if (action == "Team")
                {
                    if (String.IsNullOrWhiteSpace(teamName))
                    {
                        Console.WriteLine("A name should not be empty.");
                        Environment.Exit(0);
                    }
                    Team team = new Team(teamName);
                    teams.Add(teamName, team);
                }
                try
                {
                    if (action == "Add")
                    {
                        if (!teams.ContainsKey(teamName))
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        string playerName = commandArgs[2];
                        int endurance = int.Parse(commandArgs[3]);
                        int sprint = int.Parse(commandArgs[4]);
                        int dribble = int.Parse(commandArgs[5]);
                        int passing = int.Parse(commandArgs[6]);
                        int shooting = int.Parse(commandArgs[7]);
                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

                        teams[teamName].AddPlayer(player);

                    }
                    else if (action == "Remove")
                    {
                        string playerName = commandArgs[2];
                        if (teams.ContainsKey(teamName))
                        {
                            teams[teamName].RemovePlayer(playerName);
                        }
                        else
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                    }
                    else if (action == "Rating")
                    {
                        Team team = teams.Values.Where(x => x.Name == teamName).FirstOrDefault();
                        if (team == null)
                        {
                            throw new ArgumentException($"Team {teamName} does not exist.");
                        }
                        else
                        {
                            Console.WriteLine($"{teamName} - {team.Rating()}");
                        }
                    }
                    command = Console.ReadLine();
                }
                catch (Exception msg)
                {
                    Console.WriteLine(msg.Message);
                    command = Console.ReadLine();
                }
            }


        }
    }
}
