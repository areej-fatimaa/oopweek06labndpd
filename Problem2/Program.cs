using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] triangle = new char[5, 3] { { '@', ' ', ' ' }, { '@', '@', ' ' }, { '@', '@', '@' }, { '@', '@', ' ' }, { '@', ' ', ' ' } };
            char[,] oppTriangle = new char[5, 3] { { ' ', ' ', '@' }, { ' ', '@', '@' }, { '@', '@', '@' }, { ' ', '@', '@' }, { ' ', ' ', '@' } };
            Boundary b = new Boundary(new Point(0, 0), new Point(0, 90), new Point(90, 0), new Point(90, 90));
            GameObject g1 = new GameObject(triangle, new Point(7,5),b, "LeftToRight");
            GameObject g3 = new GameObject(triangle, new Point(12, 5), b, "Projectile");
            GameObject g4= new GameObject(triangle, new Point(17, 5), b, "Diagonal");
            GameObject g5= new GameObject(triangle, new Point(22, 5), b, "Patrol");
            GameObject g2 = new GameObject(oppTriangle, new Point(30,60), b, "RightToLeft");
            List<GameObject> list = new List<GameObject>();
            list.Add(g1);
            list.Add(g2);
            //list.Add(g3);
            //list.Add(g4);
            //list.Add(g5);
            while (true)
            {
                Thread.Sleep(200);
                foreach(GameObject g in list)
                {
                    g.Erase();
                    g.Move();
                    g.Draw();
                }
            }
        }
    }
}
