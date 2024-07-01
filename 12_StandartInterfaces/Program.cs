using System.Collections;

namespace _12_StandartInterfaces
{
    class StudentCard: ICloneable
    {
        public int Number { get; set; }
        public string Series { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Number : {Number}. Series : {Series}";
        }
    }
    class Student : IComparable<Student>, ICloneable // IComparable
    {
        public string FirstName { get; set; }//0x14789
        public string LastName { get; set; }//0x12589
        public DateTime Birthday { get; set; }//2000.5.5 =  2000.5.5
        public StudentCard StudentCard { get; set; }//0x369874 = 0x14789965

        public object Clone()
        {
            Student copy = (Student)this.MemberwiseClone();
            copy.StudentCard = (StudentCard)this.StudentCard.Clone();
            //copy.StudentCard = new StudentCard() {  Number = this.StudentCard.Number, 
            //    Series = this.StudentCard.Series};

            return copy;
        }

        public int CompareTo(Student? other)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
       
        //public int CompareTo(object? obj)
        //{
        //    if (obj is Student) 
        //    {
        //        return this.FirstName.CompareTo( (obj as Student)!.FirstName);
        //    }
        //    throw new NotImplementedException();                
        //}

        public override string ToString()
        {
            return $"Name : {FirstName} {LastName}. Birthday : {Birthday.ToShortDateString()}.\n" +
                $"{StudentCard}\n";
        }
    }
    class LastNameComparer : IComparer<Student> //IComparer
    {
        //public int Compare(object? x, object? y)
        //{
        //    if(x is Student && y is Student)
        //    {
        //        return (x as Student).LastName.CompareTo( (y as Student).LastName);
        //    }
        //    throw new Exception();
        //}
        public int Compare(Student? x, Student? y)
        {
            return x.LastName.CompareTo(y.LastName);
        }
    }
    class BirthdayComparer : IComparer<Student> //IComparer
    {
        public int Compare(Student? x, Student? y)
        {
            return x.Birthday.CompareTo(y.Birthday);
        }
    }
    class Auditory : IEnumerable
    {
        Student[] students;//null
        public Auditory()
        {
            students = new Student[]
            {
                new Student
                {
                     FirstName = "Olga",
                     LastName = "Ivanchuk",
                     Birthday = new DateTime(2000, 5,7),
                     StudentCard = new StudentCard {  Number = 1111, Series = "AA"}
                },
                 new Student
                {
                     FirstName = "Bob",
                     LastName = "Sincler",
                     Birthday = new DateTime(2002,12,17),
                     StudentCard = new StudentCard {  Number = 2222, Series = "BB"}
                },
                  new Student
                {
                     FirstName = "Elis",
                     LastName = "Holms",
                     Birthday = new DateTime(2004, 7,12),
                     StudentCard = new StudentCard {  Number = 3333, Series = "AA"}
                }
                
            };
           
        }

        public IEnumerator GetEnumerator()
        {
           return students.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(students);
        }
        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students,comparer);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                FirstName = "Olga",
                LastName = "Ivanchuk",
                Birthday = new DateTime(2000, 5, 7),
                StudentCard = new StudentCard { Number = 1111, Series = "AA" }
            };
            Console.WriteLine(student);

            Student copy = student.Clone() as Student; ;//0d2f1sdds = 0d2f1sdds

            Console.WriteLine(student);

            copy.FirstName = "Ivanka";
            copy.StudentCard.Number = 777777;
            copy.Birthday = new DateTime(1995,4,4); 
            Console.WriteLine(student);
            Console.WriteLine(copy);

            /*
            Auditory auditory = new Auditory();
            foreach (var student in auditory)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("Sort by name : ");
            auditory.Sort();
            foreach (var student in auditory)
            {
                Console.WriteLine(student);
            }
            auditory.Sort(new LastNameComparer());
            Console.WriteLine("------------ Sort by Lastname----------");
            foreach (var student in auditory)
            {
                Console.WriteLine(student);
            }
            auditory.Sort(new BirthdayComparer());
            Console.WriteLine("------------ Sort by Birthday----------");
            foreach (var student in auditory)
            {
                Console.WriteLine(student);
            }
            */
        }
    }
}
