namespace _08_OverloadOperator
{

    class Point_3D 
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point_3D() : this(0, 0,0) { }

        public Point_3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;  
        }
        public override string ToString()
        {
            return $"X : {X}. Y : {Y} . Z {Z}";
        }
    }
        class Point : Object
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() : this(0, 0) { }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return $"X : {X}. Y : {Y}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Point point &&
                   X == point.X &&
                   Y == point.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        //ref out - not allowed
        //public static returnType operator [symbol](parameters){ write code }
        #region Унарні оператори 
        //++, -- , -
        public static Point operator -(Point p)
        {
            Point res = new Point()
            {
                X = p.X * -1,
                Y = p.Y * -1
            };
            return res;
        }
        public static Point operator ++(Point p)
        {
            p.X++;
            p.Y++;
            return p;
        }
        public static Point operator --(Point p)
        {
            p.X--;
            p.Y--;
            return p;
        }
        #endregion
        #region Бінарні оператори 
        //+ - * / 
        public static Point operator +(Point p1, Point p2)
        {
            Point res = new Point
            {
                X = p1.X + p2.X,
                Y = p1.Y + p2.Y
            };
            return res;
        }
        public static Point operator -(Point p1, Point p2)
        {
            Point res = new Point
            {
                X = p1.X - p2.X,
                Y = p1.Y - p2.Y
            };
            return res;
        }
        public static Point operator *(Point p1, Point p2)
        {
            Point res = new Point
            {
                X = p1.X * p2.X,
                Y = p1.Y * p2.Y
            };
            return res;
        }
        public static Point operator /(Point p1, Point p2)
        {
            Point res = new Point
            {
                X = p1.X / p2.X,
                Y = p1.Y / p2.Y
            };
            return res;
        }
        #endregion
        #region Logic operators equals
        // == !=
        public static bool operator ==(Point p1, Point p2)
        {
            //return p1.X == p2.X && p1.Y == p2.Y;
            return p1.Equals(p2);
        }
        //in pair 
        public static bool operator !=(Point p1, Point p2)
        {
            //return p1.X != p2.X && p1.Y != p2.Y;
            return !(p1 == p2);
        }
        #endregion
        #region Logic operators compare
        //> < >= <=
        public static bool operator <(Point p1, Point p2)
        {
            return p1.X + p2.X < p1.Y + p2.Y;
        }
        //in pair
        public static bool operator >(Point p1, Point p2)
        {
            return !(p1 < p2);
        }
        public static bool operator <=(Point p1, Point p2)
        {
            return p1.X + p2.X <= p1.Y + p2.Y;
        }
        //in pair
        public static bool operator >=(Point p1, Point p2)
        {
            return !(p1 <= p2);
        }
        #endregion
        #region true/false operators
        public static bool operator true(Point p1)
        {
            return p1.X >= 0 && p1.Y >= 0 ;      
        }
        //in pair
        public static bool operator false(Point p1)
        {
            return p1.X < 0 || p1.Y < 0;
        }

        #endregion
        #region Оператори приведення типів даних
        public static explicit operator int(Point p1)
        {
           return  p1.X + p1.Y; 
        }
        public static implicit operator double(Point p1)
        {
            return p1.X + p1.Y; 
        }
        public static explicit operator Point_3D(Point p1)
        {
            return new Point_3D(p1.X, p1.Y, 15);
        }


        #endregion
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 5;//int ==> int
            double b = 3.14;//double ==> double

            b = a;//int ==> double; implicit 5.0000000000
            a = (int)b;//double ==> int explicit  
            Point p = new Point(1,5);
            a = (int) p;//Point ==> int
            b = p;//Point ==> double 
            Console.WriteLine(a);
            Console.WriteLine(b);

            Point_3D _3D = (Point_3D) p;
            Console.WriteLine(_3D);

            string str = "Hello";//str = 0v2d4g65d4g6
            string str2 = "Hello!";//str2 = g46d5g465df4g

            if (str.Equals(str2))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("not Equals");
            }


            Console.WriteLine(5 + 6);
            Point point1 = new Point(-7, 2);
            Point point2 = new Point(7, 2);

            if(point1)
            {
                Console.WriteLine("Point is true");
            }
            else
            {
                Console.WriteLine("Point is false");
            }
            //if (point1.Equals(point2))
            //{
            //    Console.WriteLine("Equals");
            //}
            //else
            //{
            //    Console.WriteLine("not Equals");
            //}


            Console.WriteLine($"Point : {point1}");
            Console.WriteLine($"Point : {++point1}");
            Console.WriteLine($"Point : {point1++}");
            Console.WriteLine($"Point : {--point1}");
            Console.WriteLine($"Point : {point1--}");

            Point res = -point1;
            Console.WriteLine($"Res : {res}");
            Console.WriteLine();
            Console.WriteLine($"Point1 : {point1}");
            Console.WriteLine($"Point2 : {point2}");
            res = point1 + point2;
            Console.WriteLine($"Res +  : {res}");
            res = point1 - point2;
            Console.WriteLine($"Res -  : {res}");
            res = point1 * point2;
            Console.WriteLine($"Res *  : {res}");
            res = point1 / point2;
            Console.WriteLine($"Res /  : {res}");


            if (point1 == point2)
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("not Equals");
            }

            if (point1 > point2)
            {
                Console.WriteLine(" > ");
            }
            else
            {
                Console.WriteLine(" < ");
            }
        }
    }
}
