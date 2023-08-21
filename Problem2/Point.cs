using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Point
    {
        public int X;
        public int Y;
        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Point(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
        public void SetX(int x)
        {
            this.X = x;
        }
        public void SetY(int y)
        {
            this.Y= y;
        }
        public int GetX()
        {
            return X;
        }
        public int GetY()
        {
            return Y;
        }
        public void SetXY(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
