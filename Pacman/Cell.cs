using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Cell
    {
       public char Value;
       private int X;
        private int Y;
        public Cell(char value,int X,int Y)
        {
            this.Value = value;
            this.X = X;
            this.Y = Y;
        }
        public  char GetValue()
        {
            return Value;
        }
        public void SetValue(char value)
        {
            this.Value = value;
        }
        public int GetX()
        {
            return X;
        }
        public int GetY()
        {
            return Y;
        }
        public void SetX(int x)
        {
            this.X = x;
        }
        public void SetY(int Y)
        {
            this.Y = Y;
        }
        public bool IsPacmanPresent()
        {
            if(Value=='P')
            {
                return true;
            }
            return false;
        }
        public bool IsGhostPresent()
        {
            if(Value=='G')
            {
                return true;
            }
            return false;
        }
    }
}
