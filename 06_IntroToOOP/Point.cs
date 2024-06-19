using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_IntroToOOP
{
    partial class Point
    {
        public void setXCoord(int newX)
        {
            this.xCoord = (newX >= 0) ? newX : 0;
            //if (newX >= 0)
            //    this.xCoord = newX;
            //else
            //    this.xCoord = 0;
        }
        public void setYCoord(int newY)
        {
            if (newY >= 0)
                this.yCoord = newY;
            else
                this.yCoord = 0;
        }
        public int GetX()
        {
            return this.xCoord;
        }
        public int GetY()
        {
            return this.yCoord;
        }

    }
    partial class Point
    {
        static int count;
        static Point()
        {
            count = 0;
        }
        public Point() : this(0, 0) { }
        //{
        //    xCoord = 0;
        //    yCoord = 0;
        //}
        public Point(int value) :this(value, value) { }
        //{
        //    xCoord= value;  
        //    yCoord= value;  
        //}
        public Point(int xCoord, int y) 
        {
            //t$ two four
            //setXCoord(xCoord);
            this.XCoord = xCoord;
            // setYCoord(y);
            YCoord = y;
            Type = "2D_Point";
            count++;
        }
    }

    }
