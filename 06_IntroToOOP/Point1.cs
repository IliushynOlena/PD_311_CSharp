namespace _06_IntroToOOP
{
    partial class Point//partial
    {
        //Full property
        private int xCoord;
        public int XCoord//int value;
        {
            get { return this.xCoord; }
            set { this.xCoord = (value >= 0) ? value : throw new Exception("Incorrect value"); }
        }

        //private string name;
        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        //Auto property prop + TAB
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; }//readonly property
        public string Color { get; private set; } = "White";

        //Full property propfull + TAB
        //private int yCoord;
        private int yCoord;

        public int YCoord
        {
            get { return yCoord; }
            set
            {
                if (value >= 0)
                {
                    yCoord = value;
                }
                else
                {
                    yCoord = 0;
                }
            }
        }     
      
        public void Print()
        {
            Console.WriteLine($"X: {xCoord} . Y : {yCoord}");
        }
        public override string ToString()
        {
            return $"X: {xCoord} . Y : {yCoord}";
        }

    }
}
