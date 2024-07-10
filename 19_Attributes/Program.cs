using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _19_Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class | AttributeTargets.Constructor)]
    class CoderAttribute : Attribute
    {
        public string Name { get; set; } = "Olena";
        public DateTime Date { get; set; } =DateTime.Now;
        public CoderAttribute() { }
        public CoderAttribute(string name, string date)
        {
            try
            {
                Name = name;
                Date = DateTime.Parse(date);//2000-5-12
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }          
        }
        public override string ToString()
        {
            return $"Coder : {Name}. Date : {Date.ToShortDateString()}";
        }

    }
    [Obsolete, Serializable]
    [Coder]
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        [CoderAttribute]
        public Employee() { }
     

        [Coder("Bob", "2024-07-10")]
        public void IncreaseSalary(double value)
        {
            Salary += value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
    
            Console.WriteLine("Attributes of Class Employee");
            foreach (var item in typeof(Employee).GetCustomAttributes(true))
            {
                Console.WriteLine(item.ToString());

            }

            Console.WriteLine("Attributes of members of  Class Employee");
            foreach (MemberInfo item in typeof(Employee).GetMembers())
            {
                Console.WriteLine("\t" + item.ToString());
                foreach (var attr in item.GetCustomAttributes())
                {
                    Console.WriteLine(attr);
                }

            }






        }
    }
}
