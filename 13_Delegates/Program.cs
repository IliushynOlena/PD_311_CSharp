namespace _13_Delegates
{
    //class MyDelegate : MulticastingDelegate
    //{

    //}

    public delegate int IntDelegate(double a);

    public delegate void SetStringDelegate(string s);
    public delegate double GetDoubleDelegate();
    public delegate void VoidDelegate();
    public class SuperClass
    {
        public void Print(string str)
        {
            Console.WriteLine(str + "!!!!!");
        }
        public static double GetKoef()
        {
            double res = new Random().NextDouble();
            return res;
        }
        public double GetNumber()
        {
            return new Random().Next();

        }
        public void DoWork()
        {
            Console.WriteLine("I do some work....");
        }
        public void Test()
        {
            Console.WriteLine("I testing....");
        }
    }
    public delegate double CalculatorDelegate(double x, double y);
    class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Multy(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            if (y != 0)
            {
                return x / y;
            }
            throw new DivideByZeroException();
        }
    }



    public delegate int ChangeDelegate(int value);
    internal class Program
    {
        public static void DoOperation(double a, double b, CalculatorDelegate operation)
        {
            Console.WriteLine(operation.Invoke(a, b));
        }
        public static void ChangeElements(int[] arr, ChangeDelegate change )
        {
            //1 4 3 4 5 6
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = change.Invoke(arr[i]);     
            }
        }
        static int Sqr(int v)
        {
            return v * v;
        }
        static int Increment(int v)
        {
            return ++v;
        }
        static int Decrement(int v)
        {
            return --v;
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 4, 7, 8, 6, 5, 3, 4, 2, 14, 7, 5, 12 };
            foreach (int i in arr) Console.Write(i + " "); Console.WriteLine();
            ChangeElements(arr, Sqr);
            foreach (int i in arr) Console.Write(i + " "); Console.WriteLine();
            ChangeElements(arr, Increment);
            foreach (int i in arr) Console.Write(i + " "); Console.WriteLine();
            ChangeElements(arr, Decrement);
            foreach (int i in arr) Console.Write(i + " "); Console.WriteLine();
            //ChangeElements(arr, delegate(int v) { return v + 10; });
            ChangeElements(arr, (v) =>  v + 10);
            foreach (int i in arr) Console.Write(i + " "); Console.WriteLine();
            /*
            Calculator calculator = new Calculator();
            CalculatorDelegate calcDelegate = null;
            calcDelegate += calculator.Add;
            calcDelegate += calculator.Sub;
            calcDelegate += calculator.Multy;
            calcDelegate += calculator.Div;
            calcDelegate -= calculator.Div;
            foreach (var item in calcDelegate.GetInvocationList())
            {
                Console.WriteLine($"Res : {(item as CalculatorDelegate)!.Invoke(100, 15)}");
            }

            DoOperation(100, 7, calculator.Add);
            DoOperation(100, 7, calculator.Sub);
            DoOperation(100, 7, calculator.Multy);
            DoOperation(100, 7, calculator.Div);
            */
            /*
            Calculator calculator = new Calculator();
            double x, y;
            int key;
            do
            {
                CaclulatorDelegate calcDelegate = null;
                Console.WriteLine("Enter first number ");
                x = double.Parse(Console.ReadLine()!);
                Console.WriteLine("Enter second number ");
                y = double.Parse(Console.ReadLine()!);
                Console.WriteLine("Add  - 1 ");
                Console.WriteLine("Sub  - 2 ");
                Console.WriteLine("Mult  - 3 ");
                Console.WriteLine("Divide  - 4 ");
                Console.WriteLine("Exit  - 0 ");
                key = int.Parse(Console.ReadLine()!);
                switch (key)
                {
                    case 1:
                        calcDelegate = new CaclulatorDelegate(calculator.Add);
                        break;
                    case 2:
                        calcDelegate = new CaclulatorDelegate(calculator.Sub);
                        break;
                    case 3:
                        calcDelegate = calculator.Multy;
                        break;
                    case 4:
                        calcDelegate = calculator.Div;
                        break;
                    case 0:
                        Console.WriteLine("Good  Buy");
                        break;
                    default:
                        Console.WriteLine("Error choice......");
                        break;
                }

                Console.WriteLine("Res = " + calcDelegate?.Invoke(x, y));
            } while (key != 0);
            */
            /*
           SuperClass superClass = new SuperClass();
           superClass.DoWork();

            GetDoubleDelegate method = new GetDoubleDelegate(superClass.GetNumber);
           Console.WriteLine(method());
            Console.WriteLine(method?.Invoke());

            GetDoubleDelegate[] arr = new GetDoubleDelegate[]
            {
                SuperClass.GetKoef,
                new GetDoubleDelegate(superClass.GetNumber)
            };
            Console.WriteLine(arr[0].Invoke()); ;
            Console.WriteLine(arr[1].Invoke()); ;

            SetStringDelegate setString = new SetStringDelegate(superClass.Print);
            setString.Invoke("Hello academy");

            VoidDelegate @void = new VoidDelegate(superClass.DoWork);
            @void.Invoke();


            //Delegate.Combine(method, SuperClass.GetKoef);   
            method += new GetDoubleDelegate(SuperClass.GetKoef);
            method += SuperClass.GetKoef;
            method += superClass.GetNumber;
            method += superClass.GetNumber;


            foreach (var item in method.GetInvocationList())
            {
                Console.WriteLine( (item as GetDoubleDelegate)!.Invoke());
            }

            Console.WriteLine($"Last Method {method.Invoke()}");}
            */
        }
    }
}
