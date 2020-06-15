using System;

namespace FootballTeamGenerator
{
    public class StartUp
    {
       
        static void Main(string[] args)
        {
            try
            {
                var command = Console.ReadLine().Split(";");
                var team = new Team(command[1]);
                while (true)
                {
                    try
                    {
                        command = Console.ReadLine().Split(";");
                        var currentcommand = command[0];
                        if (currentcommand == "END")
                        {
                            break;
                        }
                        switch (currentcommand)
                        {
                            case "Add":
                                if (command[1] != team.Name)
                                {
                                    throw new Exception($"Team {command[1]} does not exist.");
                                }
                                else
                                {
                                    var playername = command[2];
                                    var Endurance = int.Parse(command[3]);
                                    var Sprint = int.Parse(command[4]);
                                    var Dribble = int.Parse(command[5]);
                                    var Passing = int.Parse(command[6]);
                                    var Shooting = int.Parse(command[7]);
                                    var player = new Player(playername, Endurance, Shooting, Sprint, Dribble, Passing);
                                    team.Addplayer(player);
                                }
                                break;
                            case "Remove":
                                var playertoremove = command[2];
                                team.Removeplayer(playertoremove);
                                break;
                            case "Rating":
                                if (command[1] != team.Name)
                                {
                                    throw new Exception($"Team {command[1]} does not exist.");
                                }
                                Console.WriteLine($"{team.Name} - {team.Rating}");
                                break;
                        }
                    }
                    catch (Exception ex) 
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
