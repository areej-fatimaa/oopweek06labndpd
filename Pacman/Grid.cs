using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Pacman
{
    class Grid
    {
       public  Cell[,] maze;
        private int RowSize;
       private  int ColSize;
        public Grid (int rowSize,int colSize,string path)
        {
            this.RowSize = rowSize;
            this.ColSize=colSize;
            LoadFile(path);
        }
        public Cell[,] LoadFile(string path)
        {
            String[] record = File.ReadAllLines(path);
            maze = new Cell[RowSize, ColSize];
            for (int i = 0; i < ColSize; i++)
            {
                for (int x = 0; x < RowSize; x++)
                {
                    Char Value = record[x][i];
                    maze[x, i] = new Cell(Value, x, i);
                }
            }
            return maze;
        }
        public void Draw()
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x,y].GetValue());
                }
                Console.WriteLine();
            }
        }
        public Cell GetLeftCell(Cell cell)
        {
            return maze[cell.GetX(), cell.GetY() - 1];
        }
        public Cell GetRightCell(Cell cell)
        {
            return maze[cell.GetX(), cell.GetY() + 1];
        }
        public Cell GetUpCell(Cell cell)
        {
            return maze[cell.GetX() + 1, cell.GetY()];
        }
        public Cell GetDownCell(Cell cell)
        {
            return maze[cell.GetX() - 1, cell.GetY()];
        }
        public Cell FindPacman()
        {
            for (int i=0;i<RowSize;i++)
            {
                for(int j=0;j<ColSize;j++)
                {
                    if (maze[i, j].Value == 'P')
                        return maze[i, j];
                }
            }
            return null;
        }
        public Cell FindGhost()
        {
            for (int i = 0; i < RowSize; i++)
            {
                for (int j = 0; j < ColSize; j++)
                {
                    if (maze[i, j].Value == 'G')
                        return maze[i, j];
                }
            }
            return null;
        }
    }  
}
