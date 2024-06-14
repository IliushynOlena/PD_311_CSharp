using System.Collections.Specialized;
using System.Text;

namespace _05_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "hello world";
           
            str += "world";
            str += "world";
            str += "world";
            str += "world";
            str += "world";
            str += "world";
            str += "world";
            str += "world";
            str += "world";

            StringBuilder  builder = new StringBuilder();
            Console.WriteLine($"Length : {builder.Length}");
            Console.WriteLine($"Capacity : {builder.Capacity}");
            builder.Append("hello");
            builder.Append("hello");
            builder.Append("hello");
            Console.WriteLine(builder);
            Console.WriteLine($"Length : {builder.Length}");
            Console.WriteLine($"Capacity : {builder.Capacity}");
            builder.AppendLine("dngdkhkd");
            builder.Append("hello");
            Console.WriteLine(builder);
            Console.WriteLine($"Length : {builder.Length}");
            Console.WriteLine($"Capacity : {builder.Capacity}");
            builder.Append("hello");
            builder.Append("hello");
            Console.WriteLine(builder);
            Console.WriteLine($"Length : {builder.Length}");
            Console.WriteLine($"Capacity : {builder.Capacity}");
            



        }
    }
}
