using System;
using System.Collections.Generic;

namespace Lab4_
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            company.listOfworkers = new List<Worker>();

            Worker leader = new Leader("Керiвник", 2);
            leader.Salary(1000m);
            company.AddWorker(leader);

            Console.WriteLine();
            var manager = new Manager("Менеджер", 5);
            manager.Salary(1200m);
            manager.Subordinates[0] = "sub1";
            manager.Subordinates[1] = "sub2";
            manager.Subordinates[2] = "sub3";
            manager.CountSuborinates();
            company.AddWorker(manager);

            Console.WriteLine();
            var engineer = new Engineer("Iнженер", 5);
            engineer.Salary(1150m);
            engineer.amountOfWeekends(90);
            company.AddWorker(engineer);
            company.AddWorker(new Engineer("Iнженер", 2));

            Console.WriteLine();
            var mechanic = new Mechanic("Механiк", 6);
            mechanic.Salary(900m);
            company.AddWorker(mechanic);

            Console.WriteLine(); 
            var engineerArchitect = new EngineerArchitect("Iнженер-архiтектор", 3);
            engineerArchitect.Salary(1500m);
            engineerArchitect.amountOfWeekends(80);
            company.AddWorker(engineerArchitect);

            Console.WriteLine();
            company.WorkersAmount();

            Console.ReadLine();
        }
    }
    class Company
    {
        public List<Worker> listOfworkers { get; set; }
        public void AddWorker(Worker worker)
        {
            listOfworkers.Add(worker);
            Console.WriteLine(worker.Name + " був доданий до компанiї");
        }

        public void WorkersAmount()
        {
            int EngineerCount = 0, EngineerArchitectCount = 0;
            int LeaderCount = 0;
            int ManagerCount = 0;
            int MechanicCount = 0;

            foreach (var value in listOfworkers)
            {
                Type t = value.GetType();
                if (t.Equals(typeof(Engineer)))
                    EngineerCount++;
                else if (t.Equals(typeof(Leader)))
                    LeaderCount++;
                else if (t.Equals(typeof(Manager)))
                    ManagerCount++;
                else if (t.Equals(typeof(Mechanic)))
                    MechanicCount++;
                else if (t.Equals(typeof(EngineerArchitect)))
                    EngineerArchitectCount++;
            }

            Console.WriteLine("Кiлькiсть iнженерiв у компанiї: " + EngineerCount);
            Console.WriteLine("Кiлькiсть iнженерiв-архiтекторiв у компанiї: " + EngineerArchitectCount);
            Console.WriteLine("Кiлькiсть керiвникiв у компанiї: " + LeaderCount);
            Console.WriteLine("Кiлькiсть менеджерiв у компанiї: " + ManagerCount);
            Console.WriteLine("Кiлькiсть механiкiв у компанiї: " + MechanicCount);
        }
    }

    abstract class Worker
    {
        public string Name { get; }
        public int Experience { get; }
        public decimal salary { get; private set; }
        public Worker(string name, int experience)
        {
            Name = name;
            Experience = experience;
        }
        public void Salary(decimal Salary)
        { 
            salary = Salary; 
            Console.WriteLine($"Зарплата {Name}а {salary}$"); 
        }
    }

    class Leader : Worker
    {
        public Leader(string name, int experience) : base(name, experience) { }
    }

    class Manager : Worker
    {
        private string[] _Subordinates = new string[50];
        public string[] Subordinates { get { return _Subordinates; } }
        public Manager(string name, int experience) : base(name, experience) { }
        public void CountSuborinates()
        {
            int Count = 0;
            for (int i = 0; i < Subordinates.Length; i++)
            {
                if (Subordinates[i] != null)
                    Count++;
            }
            Console.WriteLine("Кiлькiсть пiдлеглих у менеджера: " + Count);
        }
    }

    class Engineer : Worker
    {
        public Engineer(string name, int experience) : base(name, experience) { }
        private int WeekendsAmount { get; set; }
        public void amountOfWeekends(int amount)
        {
            WeekendsAmount = amount;
            Console.WriteLine($"Kiлькiсть вихiдних в роцi у {Name}a: " + WeekendsAmount);
        }
    }

    class Mechanic : Worker
    {
        public Mechanic(string name, int experience) : base(name, experience) { }
    }

    class EngineerArchitect:Engineer
    {
        public EngineerArchitect(string name, int experience) : base(name, experience) { }
    }
}
