namespace _07_StructRefOut
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
    //Access Spetificators
    /*
     *private (default for all feild)
     *public
     *protected
     *internal
     *protected internal
     */
    struct _2D_Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public _2D_Point(int x, int y)
        {
            X = x;
            Y = y;  
        }
        public void Print()
        {
            Console.WriteLine($"X : {X} . Y : {Y}");
        }
    }

    internal class Program
    {
        static void MethodWithParams(string name, int age, int average, params int[] marks)
        {
            Console.WriteLine("---------------" + name + "------------");
            Console.WriteLine("---------------" + age + "------------");
            Console.WriteLine("---------------" + average + "------------");
            foreach (var item in marks)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void Modify(ref int num, ref string str,ref Point point)
        {
            num += 1;
            str += "!";
            point.X ++;
            point.Y ++;
        }
        //static void GetCurrentTime(ref int hour,ref int minute,ref int second)
        //{
        //    hour = DateTime.Now.Hour;
        //    minute = DateTime.Now.Minute;    
        //    second = DateTime.Now.Second;
        //    Console.WriteLine($"{hour}:{minute}:{second}");
        //}
        static void GetCurrentTime(out int hour, out int minute, out int second)
        {
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
            //Console.WriteLine($"{hour}:{minute}:{second}");
        }
        static void Main(string[] args)
        {
            Point point = new Point();  //new - create dynamic memory
            _2D_Point _Point = new _2D_Point();//invoke default constructor
            /* numbers = 0
             * boolean = false
             * references = null
             */
            Point p1;
            _2D_Point p2;
            p2.Print();
            int a;



            /*
            //out
            int h, m , s ;
            //Console.WriteLine($"{h}:{m}:{s}");
            //GetCurrentTime(ref h,ref m,ref s);    
            GetCurrentTime(out h, out m, out s);    
            Console.WriteLine($"{h}:{m}:{s}");
            //ref
            int num = 10;
            string str = "Hello academy";
            Point point = new Point() {  X = 5, Y = 7, Z = 1};
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            Console.WriteLine($"Point x = {point.X}. y = {point.Y}");
            Modify(ref num,ref str,ref point);
            Console.WriteLine($"Num = {num}");
            Console.WriteLine($"Str = {str}");
            Console.WriteLine($"Point x = {point.X}. y = {point.Y}");

            //Params
            int[] marks = [12, 12, 3, 4, 5, 6, 7, 8, 9];
            //MethodWithParams("Bob", marks);
            //MethodWithParams("Tom", new int[] {11,12,9,8,12,10,11,12});
            MethodWithParams("Ivanka", 11,12,9,8,12,10,11,12,12,11,9,6,5,4,8,9,12,12,11);


            //Point p = new Point();
            //_2D_objects.Point point = new _2D_objects.Point();  
            */
        }
    }
}
namespace _2D_objects
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}

