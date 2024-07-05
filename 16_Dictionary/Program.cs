namespace _16_Dictionary
{
    class Person
    {
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> countries = new Dictionary<string, string>();
            countries.Add("UA", "Ukraine");
            countries.Add("UK", "United Kindom");
            countries.Add("USA", "America");
            countries.Add("FR", "France");
            countries.Add("PL", "Poland");
            countries.Add("GB", "Great Britain");
            //countries.Add("GB", "Great Britain");

            foreach (KeyValuePair<string,string> country in countries)
            {
                Console.WriteLine(country.Key + " - " + country.Value);
            }

            string c = countries["USA"];//get element by key
            Console.WriteLine(c);

            countries["USA"] = "United States";//set new value by key
            countries["IN"] = "India";
            countries.Remove("PL");
            Console.WriteLine();
            foreach (KeyValuePair<string, string> country in countries)
            {
                Console.WriteLine(country.Key + " - " + country.Value);
            }

            ////////////////////////////////////////////
            Dictionary<char, Person> people = new Dictionary<char, Person>();

            people.Add('b', new Person() { Name = "Bob" });
            people.Add('t', new Person() { Name = "Tom" });
            people.Add('j', new Person() { Name = "Jask" });
            people.Add('r', new Person() { Name = "Rita" });
            foreach (KeyValuePair<char, Person> p in people)
            {
                Console.WriteLine(p.Key + " - " + p.Value.Name);
            }

            if(people.ContainsKey('f'))
            {
                people['f'].Name = "Fedir";
            }
            else
            {
                Console.WriteLine("Error key");
            }

            foreach (var item in people.Keys)
            {
                Console.WriteLine(item);
            }

            foreach (var item in people.Values)
            {
                Console.WriteLine(item.Name);
            }



        }
    }
}
