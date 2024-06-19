using System.ComponentModel.Design;

namespace _06_IntroToOOP
{
    struct MyStruct
    {
        public int x;
        public int y;   

    }

    partial class Point
    {
        public void Test()
        {
            Console.WriteLine(  "Testing method");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           
            try
            {

                //Point[] points = new Point[5];
                //for (int i = 0; i < points.Length; i++)
                //{
                //    points[i] = new Point() { }
                //}
                

                Point p = new Point(-4, 8);
           
                p.Print();
                p.Address = "Rivne . Soborna 16";//set
                Console.WriteLine(  p.Address);//get
                Console.WriteLine(p);
                //p.setXCoord(-100);
                //p.setYCoord(200);
                Console.WriteLine(p.GetX());
                Console.WriteLine(p);

                p.XCoord = 200;// 200 = value set
                int x = p.XCoord;
                Console.WriteLine(x);//get
                p.Name = "Point2D";//set 
                Console.WriteLine(p.Name);//get

                Console.WriteLine(p.Type);

                p.Test();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
           

            //MyClass @class = new MyClass();
            //@class.Print();
            //Console.WriteLine(@class.ToString());








        }
    }
}
