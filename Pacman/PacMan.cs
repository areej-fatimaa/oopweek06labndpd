using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class PacMan
    {
        private int X;
        private int Y;
        private Grid mazeGrid;
        public PacMan (int X,int Y,Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.mazeGrid = mazeGrid;
        }
        public void Remove()
        {
            mazeGrid.maze[Y, X].SetValue(' ');
        }
        public void Draw()
        {
            mazeGrid.maze[Y, X].SetValue('P');
        }
        public void MoveLeft()
        {
           if(mazeGrid.GetLeftCell(mazeGrid.maze[Y,X]).GetValue()==' ')
            {
                X--;
            }
        }
        public void MoveRight()
        {
            if (mazeGrid.GetRightCell( mazeGrid.maze[Y, X]).GetValue() == ' ')
            {
                X++;
            }
        }
        public void MoveDown()
        {
            if (mazeGrid.GetUpCell( mazeGrid.maze[Y, X]).GetValue() == ' ')
            {
                Y++;
            }
        }
        public void MoveUp()
        {
            if (mazeGrid.GetDownCell( mazeGrid.maze[Y, X]).GetValue() == ' ')
            {
                Y--;
            }
        }
    }
}
