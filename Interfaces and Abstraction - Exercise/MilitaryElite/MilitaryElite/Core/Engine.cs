using MilitaryElite.Contracts;
using MilitaryElite.Core.Contracts;
using MilitaryElite.IO;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        private ICollection<ISoldier> soldiers;
        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReader reader, IWriter writer)
            :this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command;
            while((command = this.reader.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ");
                string soldier = cmdArgs[0];
                int id = int.Parse(cmdArgs[1]);
                string firstname = cmdArgs[2];
                string lastname = cmdArgs[3];
                ISoldier soldier1 = null;
                if(soldier == "Private")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    soldier1 = new Private(id, firstname, lastname, salary);
                }
                else if(soldier == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    LieutenantGeneral general = new LieutenantGeneral(id, firstname, lastname, salary);
                    foreach (var pid in cmdArgs.Skip(5))
                    {
                        ISoldier @private = this.soldiers.First(s => s.Id == int.Parse(pid));
                        general.AddPrivates(@private);
                    }
                    soldier1 = general;
                }
                else if(soldier == "Engineer")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        IEngineer engineer = new Engineer(id, firstname, lastname, salary, corps);
                        string[] repairs = cmdArgs.Skip(6).ToArray();
                        for (int i = 0; i < repairs.Length; i += 2)
                        {
                            string partname = repairs[i];
                            int hours = int.Parse(repairs[i + 1]);

                            Irepair irepair = new Repair(partname, hours);
                            engineer.AddRepair(irepair);
                        }
                        soldier1 = engineer;
                    }
                    catch (Exception ex)
                    {

                        continue; 
                    }
                }
                else if(soldier == "Commando")
                {
                    decimal salary = decimal.Parse(cmdArgs[4]);
                    string corps = cmdArgs[5];
                    try
                    {
                        ICommando commando = new Commando(id, firstname, lastname, salary, corps);
                        string[] missionargs = cmdArgs.Skip(6).ToArray();
                        for (int i = 0; i < missionargs.Length; i += 2)
                        {
                            try
                            {
                                string mission = missionargs[i];
                                string missionstate = missionargs[i + 1];
                                IMission missions = new Missions(mission, missionstate);
                                commando.AddMission(missions);
                            }
                            catch (Exception ex)
                            {

                                continue;
                            }
                            
                        }
                        soldier1 = commando;
                    }
                    catch (Exception ex)
                    {
                        continue;
                        
                    }
                }
                else if(soldier == "Spy")
                {
                    int codenumber = int.Parse(cmdArgs[4]);
                    soldier1 = new Spy(id, firstname, lastname, codenumber);
                }
                if (soldier1 != null)
                {
                    this.soldiers.Add(soldier1);
                }
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
