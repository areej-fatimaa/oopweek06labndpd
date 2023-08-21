using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class GameObject
    {
        public char[,] Shape;
        public Point StraightPoint;
        public Boundary Premises;
        public string Direction;
        public GameObject()
        {
            Shape = new char[1, 3] { { '-', '-', '-' } };
            StraightPoint = new Point();
            Premises = new Boundary();
            Direction = "LeftToRight";
        }
        public GameObject (char[,] shape,Point straightPoint)
        {
            this.Shape = shape;
            this.StraightPoint = straightPoint;
            Premises = new Boundary();
            Direction = "LeftToRight";
        }
        public GameObject(char[,] shape, Point straightPoint,Boundary permises,string direction)
        {
            this.Shape = shape;
            this.StraightPoint = straightPoint;
            this.Premises = permises;
            this.Direction = direction;
        }
        public void Draw()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    int x = StraightPoint.X + i;
                    int y = StraightPoint.Y + j;
                    Console.SetCursorPosition(y, x);
                    Console.Write(Shape[i, j]);
                }
            }
        }
        public void Erase()
        {
            for(int i=0;i<Shape.GetLength(0);i++)
            {
                for (int j=0;j<Shape.GetLength(1);j++)
                {
                    int x = StraightPoint.X + i;
                    int y = StraightPoint.Y + j;
                    Console.SetCursorPosition(y, x);
                    Console.Write("   ");
                }
            }
               
        }
        public void Move()
        {
            if (Direction == "LeftToRight")
            {
                if (StraightPoint.Y + Shape.GetLength(1) < Premises.TopRight.Y)
                {
                    StraightPoint.Y++;
                }
            }
            if (Direction == "RightToLeft")
            {
                if (StraightPoint.Y > Premises.TopLeft.Y)
                {
                    StraightPoint.Y--;
                }
                else
                {
                    Direction = "LeftToRight";
                }
            }
            if (Direction == "Patrol")
            {
                if (StraightPoint.Y > Premises.TopLeft.Y)
                {
                    StraightPoint.Y--;
                }
                else
                {
                    Direction = "RightToLeft";
                    StraightPoint.Y++;
                }
            }
            if (Direction == "projectile")
            {
                if (StraightPoint.X > Premises.TopLeft.X && StraightPoint.Y < Premises.TopRight.Y)
                {
                    StraightPoint.X -= 5;
                    StraightPoint.Y += 5;
                }
                else if (StraightPoint.Y < Premises.TopRight.Y)
                {
                    StraightPoint.Y += 2;
                }
                else if (StraightPoint.Y < Premises.BottomRight.Y)
                {
                    StraightPoint.Y += 4;
                }
            }
            if (StraightPoint.X < Premises.BottomRight.X && StraightPoint.Y < Premises.BottomRight.Y)
            {
                StraightPoint.X++;
                StraightPoint.Y++;
            }
        }
    }

    }
