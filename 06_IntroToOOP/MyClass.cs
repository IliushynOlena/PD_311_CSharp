namespace _06_IntroToOOP
{
    //Access Spetificators
    /*
     *private (default for all feild)
     *public
     *protected
     *internal
     *protected internal
     */
    public class MyClass : Object
    {
        //private:
        private int number;
        private string name;
        private const float PI = 3.14f;
        private readonly int id;
        public MyClass()
        {
            name = "Bob";
            id = 10;
        }
        //void setId(int id)
        //{
        //    this.id = id;
        //}
        public void Print()
        {
            Console.WriteLine($"Name : {name} . Id {id} ");
        }
        public override string ToString()
        {
            return $"Name : {name} . Id {id} ";

        }

    }
}
