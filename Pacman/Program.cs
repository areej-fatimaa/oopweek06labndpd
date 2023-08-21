using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EZInput;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman
{
    class Program
    {
        static void Main(string[] args)
        {
            string path="maze.txt";
            Grid maze = new Grid(23, 60, path);
            PacMan player = new PacMan(3, 3, maze);
            Ghost g1 = new Ghost(4, 4, 'H', "Left", 1F,' ', maze);
            Ghost g2 = new Ghost(5, 5, 'V', "Up", 1F, ' ', maze);
            Ghost g3 = new Ghost(7, 7, 'V', "Up", 1F, ' ', maze);
            List<Ghost> enemy = new List<Ghost>();
            enemy.Add(g1);
            enemy.Add(g2);
            enemy.Add(g3);
            player.Draw();
            bool gamerunning = true;
            while (gamerunning)
            {
                Console.Clear();
                maze.Draw();
                Thread.Sleep(90);
                foreach(Ghost g in enemy)
                {
                    g.Remove();
                    g.Move();
                    g.Draw();
                }
                player.Remove();
                if (EZInput.Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    player.MoveLeft();
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    player.MoveRight();
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    player.MoveUp();
                }
                if (EZInput.Keyboard.IsKeyPressed(Key.DownArrow))
                {
                    player.MoveDown();
                }
                player.Draw();


            }
            Console.ReadKey();
        }
    }
}
