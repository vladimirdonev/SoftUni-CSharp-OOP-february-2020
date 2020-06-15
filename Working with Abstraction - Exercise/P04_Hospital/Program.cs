using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<string>> Doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();


            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] input = command.Split();
                var departament = input[0];
                var DoctorFirstname = input[1];
                var Doctorlastname = input[2];
                var patient = input[3];
                var Doctorname = DoctorFirstname + Doctorlastname;

                if (!Doctors.ContainsKey(DoctorFirstname + Doctorlastname))
                {
                    Doctors[Doctorname] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();
                    for (int stai = 0; stai < 20; stai++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                bool Capacityrinroom = departments[departament].SelectMany(x => x).Count() < 60;
                if (Capacityrinroom)
                {
                    int room = 0;
                    Doctors[Doctorname].Add(patient);
                    for (int patientcount = 0; patientcount < departments[departament].Count; patientcount++)
                    {
                        if (departments[departament][patientcount].Count < 3)
                        {
                            room = patientcount;
                            break;
                        }
                    }
                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                string[] args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out int room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", Doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}
