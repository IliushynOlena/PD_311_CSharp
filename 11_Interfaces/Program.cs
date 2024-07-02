using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace _11_Interfaces
{
    interface IWorker
    {
        public bool IsWorking { get; }//false
        public string Name { get; }//null
        void RunWorker();
        event EventHandler RunWorkerCompleted;

    }
    abstract class Human
    {
        //private
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday{ get; set; }
        public static void Test() { Console.WriteLine("Hello abstract class"); }

        public override string ToString()
        {
            return $"First name : {FirstName} . Last name : {LastName}. Birthday : " +
                $"{Birthday.ToShortDateString()} ";
        }
    }
    abstract class Employee : Human
    {
        public string Position { get; set; }
        public double Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nPosiotion : {Position} . Salary : {Salary} $";
        }
    }

    interface IWorkable
    {
        bool IsWorking { get; }
        string Work();
    }
    interface IManager
    {
        List<IWorkable> ListOfWorkers{ set; get; }
        void Control();
        void MakeBudget();
        void Organize();
    }
    class Director : Employee, IManager//implement(realize)
    {
        public List<IWorkable> ListOfWorkers { get ; set; }

        public void Control()
        {
            Console.WriteLine("Controling work.....");
        }

        public void MakeBudget()
        {
            Console.WriteLine("I count money.....");
        }

        public void Organize()
        {
            Console.WriteLine("I organize all work...");
        }
    }
    class Seller : Employee, IWorkable
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "Selling product";
        }
    }
    class Cashier : Employee, IWorkable
    {
        public bool IsWorking => true;

        public string Work()
        {
            return "Getting pay for product";
        }
    }
    class Administrator : Employee, IManager, IWorkable
    {
        public bool IsWorking => true;

        public List<IWorkable> ListOfWorkers { get ; set ; }//null

        public void Control()
        {
            Console.WriteLine("I am a bosssssss.....");
        }

        public void MakeBudget()
        {
            Console.WriteLine("Xaxaxaxaxaxxaxax. I have many money. ");
        }

        public void Organize()
        {
            Console.WriteLine("I organize work");
        }

        public string Work()
        {
           return "I do my work again (((((((";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo("test.txt");
           
            File.Create(File.ReadAllText(file.FullName));   

            //Director director = new Director()
            IManager director = new Director()
            {
                 FirstName = "Boss",
                 LastName = "Nicson",
                 Birthday = new DateTime(1833, 12,21),
                 Position = "Director",
                 Salary = 200000
            }; 
            director.MakeBudget();
            director.Control();
            director.Organize();

            //IWorkable seller = new Seller()
            Seller seller = new Seller()
            {
                FirstName = "Olga",
                LastName = "Petruk",
                Birthday = new DateTime(2000, 5, 14),
                Position = "Seller",
                Salary = 7350
            };
            //seller.Salary = 80000;
            Console.WriteLine(seller.Work()); ;    
            Console.WriteLine(seller);

            if (seller is Employee) 
            {
                Console.WriteLine($"Sellers salary : {(seller as Employee)!.Salary} "); 
            }

            director.ListOfWorkers = new List<IWorkable>             
            { 
               seller, 
               new Administrator()
               {
                    FirstName = "Vova",
                    LastName = "Ivanchuk",
                    Birthday = new DateTime(1995, 7, 21),
                    Position = "Admin",
                    Salary = 25000
               },
               new Cashier()
               {
                     FirstName = "Maria",
                    LastName = "Ilchuk",
                    Birthday = new DateTime(2002, 3, 7),
                    Position = "Cashier",
                    Salary = 10000
               }
            };

            foreach (IWorkable worker in director.ListOfWorkers)
            {
                Console.WriteLine(worker.Work());
                if (worker is Administrator)
                {
                    (worker as Administrator).Control();
                }
            }

            Administrator admin = new Administrator();//0hh5f4h6f54h65fh4

            IManager manager = admin;//0hh5f4h6f54h65fh4
            manager.Control();

            IWorkable work = admin;////0hh5f4h6f54h65fh4
            work.Work();

        }
    }
}
