namespace _15_Event
{
    public delegate void FinishAction();
    public delegate void ExamDelegate(string t);
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public void PassExam(string task)
        {
            Console.WriteLine($"Student : {LastName}  {FirstName} pass exam {task}");
        }
    }
    class Teacher
    {
        public event Action TestEvent;
        //public event ExamDelegate ExamDelegate;  //auto event (auto propertty)
        private ExamDelegate examDelegate;
        public event ExamDelegate ExamDelegate
        {
            add 
            {
                examDelegate += value;
                Console.WriteLine(value.Method.Name + "was added");
            } 
            remove 
            {
                examDelegate -= value;
                Console.WriteLine(value.Method.Name + "was removed");
            }  
        }
        public void CreateExam(string task)
        {
            //create exam 
            //some code


            ///call students
            examDelegate?.Invoke(task);
        }
        public void TestAction()
        {
            TestEvent.Invoke();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Student> students = new List<Student>
            {
                new Student
                {
                     FirstName = "Olga",
                     LastName = "Ivanchuk",
                     Birthdate = new DateTime(2000, 5,7),
                },
                 new Student
                {
                     FirstName = "Bob",
                     LastName = "Sincler",
                     Birthdate = new DateTime(2002,12,17),
                },
                  new Student
                {
                     FirstName = "Elis",
                     LastName = "Holms",
                     Birthdate = new DateTime(2004, 7,12),
                },
                     new Student
                {
                     FirstName = "Petro",
                     LastName = "Petruk",
                     Birthdate = new DateTime(2004, 7,12),
                }
            };

            Teacher teacher = new Teacher();
            foreach (Student student in students)
            {
                teacher.ExamDelegate += new ExamDelegate(student.PassExam);
            }
            teacher.ExamDelegate -= students[3].PassExam;
           
           // teacher.ExamDelegate = null;
            teacher.CreateExam("C# exam at 15 o'clock 16.08.2024 in 36 ayditory");

            teacher.TestEvent += Console.Clear;
            teacher.TestEvent -= Console.Clear;
            teacher.TestEvent += delegate () { Console.ForegroundColor = ConsoleColor.Green; };
            teacher.TestEvent += delegate () { Console.BackgroundColor = ConsoleColor.Yellow; };
            teacher.TestEvent -= delegate () { Console.BackgroundColor = ConsoleColor.Yellow; };
            teacher.TestEvent += () => Console.Beep(500, 1000);
            teacher.TestEvent -= () => Console.Beep(500, 1000);
            teacher.TestEvent += Teacher_TestEvent;
            teacher.TestEvent -= Teacher_TestEvent;
            teacher.TestAction();



            //callback function
            ////HardWork(Action1);//Very good
            //HardWork(delegate () { Console.WriteLine("Very good"); });
            //HardWork( ()=> Console.WriteLine("Very good" ));
            //HardWork(Action2);//Good
            //HardWork(Action3);//Soso
            //HardWork(null);//Bad


















        }

        private static void Teacher_TestEvent()
        {
            Console.WriteLine("Auto-created method by pressing TAB");
        }

        static void HardWork(FinishAction action)
        {
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Operation {i + 1} working.....");
                Thread.Sleep(random.Next(500));
                Console.WriteLine($"Operation {i + 1} finished.....");
            }
            action?.Invoke();
        }
        //static void Action1()
        //{
        //    Console.WriteLine("Very good");
        //}
        static void Action2()
        {
            Console.WriteLine(" good");
        }
        static void Action3()
        {
            Console.WriteLine("So-so");
        }

    }
}
