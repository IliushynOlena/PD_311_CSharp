using System.Net.Http.Headers;

namespace _10_Inheritance
{
    //public private protected
    abstract class Person : Object
    {
        protected string name;
        private readonly DateTime birthday;
        public Person()
        {
            name = "no name";
            birthday = new DateTime(2000, 5, 5);
        }
        public Person(string n, DateTime b)
        {
            name = n;
            if( b > DateTime.Now)
            {
                birthday = new DateTime();
            }
            else
            {
                birthday = b;   
            }
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name : {name}. Birthday : {birthday.ToShortDateString()}");
        }
        public abstract void DoWork();//=0
        public override string ToString()
        {
            return $"Name : {name}. Birthday : {birthday.ToShortDateString()}";
        }
    }
    //class Name : BaseClass, Interface1, Intercafe2
    class Worker : Person
    {
        public string Position { get; set; }
        private double salary;
        public double Salary
        {
            get { return salary; }
            set { 
                this.salary = value >= 7340 ? value : 0;                
            }
        }
        public Worker(): base()
        {         
            Position = "no position";
            Salary = 0;
        }
        public Worker(string n, DateTime b, string p, double s): base(n,b)
        {
            Position = p;
            Salary = s;//setter
        }
        public override void DoWork()
        {
            Console.WriteLine("Do some work.....");
        }
        //new or override
        public override void Print()
        {
            base.Print();   
            Console.WriteLine($"Position : {Position} . Salary : {Salary} $");
        }
    }
    sealed class Programmer: Worker
    {
        public int CodeLines { get; set; }
        public Programmer():base()
        {
            CodeLines = 0;  
        }
        public Programmer(string n, DateTime b, string p, double s): base(n,b,p,s)
        {
            CodeLines = 0;
        }
        //final => sealed 
        public sealed override void DoWork()
        {
            Console.WriteLine("Write C# code.");
        }
        public void WriteCode()
        {
            CodeLines++;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Code lines : {CodeLines} . \n");
        }
    }
    class TeamLead : Worker
    {
        public int ProjectCount { get; set; }
        public override void DoWork()
        {
            Console.WriteLine("Manage team projects ....");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
          
  
            Worker worker = new Worker("Vova",new DateTime(1995, 12, 25), "manager", 30000);
            worker.Print(); 

            Programmer programmer = new Programmer("Nick", new DateTime(1939, 5,21), "Middle", 45000);
            programmer.WriteCode();
            programmer.WriteCode();
            programmer.WriteCode();
            programmer.Print();


            Person[] people = new Person[]
            {
                //new Person(),
                worker,
                programmer,
                new Worker("Adolf", new DateTime(1941, 5,21), "Painter", 5000)
            };
            Programmer pr = null;
            //1 - use cast ()
            try
            {
                pr = (Programmer)people[1];
                pr.DoWork();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //2 - use as
            pr = people[1] as Programmer;
            if (pr != null) {
                pr.DoWork();
            }
            else { Console.WriteLine("Object is null"); }
            //3 - use is and as

            if (people[2] is Programmer) 
            {
                pr = people[2] as Programmer;
                pr.DoWork();
            }



                Console.WriteLine();
            foreach (var person in people)
            {
                Console.WriteLine("-------------- Info --------------");
                person.Print();
           
                Console.WriteLine();
            }
        }
    }
}
