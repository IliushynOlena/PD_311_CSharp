﻿namespace _09_Indexers
{

    class Laptop
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"Model : {Model}. Price : {Price}";
        }
    }
    class Shop
    {
        private Laptop[] laptops;//null
        public Shop(int size)
        {
            laptops = new Laptop[size];
        }
        public int Length
        {
            get { return laptops.Length; }
        }
        public Laptop GetLaptop(int index)
        {
            if (index >= 0 && index < laptops.Length)
            {
                return laptops[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void SetLaptop(Laptop laptop, int index)
        {
            if (index >= 0 && index < laptops.Length)
            {
                laptops[index] = laptop;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public Laptop this[int index]
        {
            get
            {
                if (index >= 0 && index < laptops.Length)
                {
                    return laptops[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set// Laptop == value
            {
                if (index >= 0 && index < laptops.Length)
                {
                    laptops[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public Laptop this[string name]
        {
            get
            {
                foreach (Laptop l in laptops)
                {
                    if (l.Model == name)
                    {
                        return l;
                    }
                }
                return null;
            }
            //private set
            //{
            //    for (int i = 0; i < laptops.Length; i++)
            //    {

            //        if (laptops[i].Model == name)
            //        {
            //            laptops[i] = value;
            //            break;
            //        }
            //    }
            //}
        }
        public int FindByPrice(double price)
        {
            for (int i = 0; i < laptops.Length; i++)
            {
                if (laptops[i].Price == price) return i;
            }
            return -1;
        }
        public Laptop this[double price]
        {
            get
            {
                int index = FindByPrice(price); 
                if(index != -1)
                {
                    return laptops[index];  
                }
                throw new Exception("Incorrect price");  

            }
            set
            {
                int index = FindByPrice(price);
                if (index != -1)
                {
                   laptops[index] = value;
                }
            }
        }
    }
    public class MultArray
    {
        private int[,] array;
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public MultArray(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            array = new int[rows, cols];
        }
        public int this[int r, int c]
        {
            get { return array[r, c]; }
            set { array[r, c] = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop(3);
            shop.SetLaptop(new Laptop() { Model = "HP", Price = 32000.99 }, 0);
            var laptop = shop.GetLaptop(0);
            Console.WriteLine(laptop);

            shop[1] = new Laptop() { Model = "ASUS", Price = 12555.33 };//set
            shop[2] = new Laptop() { Model = "MAC", Price = 100000 };//set
            Console.WriteLine(shop[1]);//get
            Console.WriteLine();
            try
            {
                for (int i = 0; i < shop.Length + 1; i++)
                {
                    Console.WriteLine(shop[i]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //shop["HP"] = new Laptop();  
            Console.WriteLine(shop["HP"]);

            shop[32000.99] = new Laptop() { Model = "DELL", Price = 10000.33 };
            Console.WriteLine(shop[10000.33]);








        }
    }
}
