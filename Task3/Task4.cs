using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
internal class Task4
{

    public interface IHours
    {
        public int Hours();
        public string Name();
    }

    public class StandartEmployee : IHours
    {
        private string name;
        private int hours;

        public StandartEmployee(string name)
        {
            this.name = name;
            hours = 40;
        }

        public int Hours()
        {
            return hours;
        }

        public string Name()
        {
            return name;
        }
    }

    public class PartTimeEmployee : IHours
    {
        private string name;
        private int hours;

        public PartTimeEmployee(string name)
        {
            this.name = name;
            hours = 20;
        }

        public int Hours()
        {
            return hours;
        }

        public string Name()
        {
            return name;
        }
    }

    public class Job
    {
        private string name;
        private int neededHour;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int NeededHour
        {
            get { return neededHour; }
            set { neededHour = value; }
        }

        private IHours employee;

        public Job(string name, int neededHour, IHours employee)
        {
            this.employee = employee;
            this.neededHour = neededHour;
            this.name = name;
        }

        public int PassWeek()
        {
            if (neededHour - employee.Hours() <= 0 || neededHour <= 0)
            {
                return 1;
            }
            neededHour -= employee.Hours();
            return 0;
        }

        public void Status()
        {
            Console.WriteLine($"Job: {name} \nHours Remaining: {neededHour}");
        }
    }

    static void Main()
    {
        List<IHours> hours = new List<IHours>();
        List<Job> jobs = new List<Job>();

        while (true)
        {
            var temp = Console.ReadLine().Split();

            if (temp[0] == "END" || temp[0] == "End")
            {
                break;
            }
            else
            {
                if (temp[0] == "StandartEmployee")
                {
                    StandartEmployee parttemp = new StandartEmployee(temp[1]);
                    hours.Add(parttemp);
                }

                else if (temp[0] == "PartTimeEmployee")
                {
                    PartTimeEmployee parttemp = new PartTimeEmployee(temp[1]);
                    hours.Add(parttemp);
                }


                else if (temp[0] == "Job")
                {
                    foreach (IHours item in hours)
                    {
                        if (item.Name() == temp[3])
                        {
                            Job job = new Job(temp[1], int.Parse(temp[2]), item);
                            jobs.Add(job);

                            break;
                        }
                    }
                }
                else if (temp[0] == "Status")
                {

                    foreach (Job item in jobs)
                    {
                        item.Status();
                    }
                }
                else if (temp[0] == "PassWeek")
                {
                    foreach (Job item in jobs)
                    {
                        if (item.PassWeek() == 1)
                        {
                            Console.WriteLine($"Job {item.Name} done");
                            jobs.Remove(item);
                            break;
                        }
                    }
                }

            }
        }
    }
}

