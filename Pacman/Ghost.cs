using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman
{
    class Ghost
    {
        private int X;
        private int Y;
        private string GhostDirection;
        private char GhostCharacter;
        private float Speed;
        private char PreviosItem;
        private float DeltaChange;
        private  Grid mazeGrid;

        public int X1 { get => X; set => X = value; }
        // for getting   int abc = ghost.X1      for setting ghost.X1 = abc

        public Ghost(int X,int Y, char ghostCharacter,string ghostDirection,float speed,char previousItem,Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.GhostCharacter = ghostCharacter;
            this.GhostDirection = ghostDirection;
            this.Speed = speed;
            this.PreviosItem = previousItem;
            this.mazeGrid = mazeGrid;
        }
        public void SetDirection(string GhostDirection)
        {
            this.GhostDirection = GhostDirection;
        }
        public string GetDirection()
        {
            return GhostDirection;
        }
        public char GetCharacter()
        {
            return GhostCharacter;
        }
        public void Remove()
        {
            mazeGrid.maze[Y, X].SetValue(' ');
        }
        public void Draw()
        {
            mazeGrid.maze[Y, X].SetValue('G');
        }
        public void ChangeDelta()
        {
            DeltaChange += Speed;
        }
        public float GetDelta()
        {
            return DeltaChange;
        }
        public void SetDeltaZero()

        {
            DeltaChange = 0;
        }
        public void MoveHorizontal(Grid mazeGrid)
        {
            if (GhostDirection == "Left")
            {
                if (mazeGrid.maze[Y, X - 1].GetValue() != '#')
                {
                    mazeGrid.maze[Y, X].SetValue(PreviosItem);
                    X--;
                    PreviosItem = mazeGrid.maze[Y, X].GetValue();
                    mazeGrid.maze[Y, X].SetValue(GhostCharacter);
                }
                if(mazeGrid.maze[Y, X - 1].GetValue() == '#')
                {
                    GhostDirection = "Right";
                }
                if (mazeGrid.maze[Y, X - 1].GetValue() == 'G')
                {
                    HandleGhostCollision();
                }

            }
            else if (GhostDirection == "Right")
            {
                if (mazeGrid.maze[Y, X + 1].GetValue() != '#')
                {
                    mazeGrid.maze[Y, X].SetValue(PreviosItem);
                    X++;
                    PreviosItem = mazeGrid.maze[Y, X].GetValue();
                    mazeGrid.maze[Y, X].SetValue(GhostCharacter);
                }
                if (mazeGrid.maze[Y, X + 1].GetValue() == '#')
                {
                    GhostDirection = "Left";
                }
                if (mazeGrid.maze[Y, X + 1].GetValue() == '#')
                {
                    HandleGhostCollision();
                }
            }
        }
        public void MoveVertical(Grid mazeGrid)
        {
            if (GhostDirection == "Up")
            {
                if (mazeGrid.maze[Y - 1, X].GetValue() != '#')
                {
                    mazeGrid.maze[Y, X].SetValue(PreviosItem);
                    Y--;
                    PreviosItem = mazeGrid.maze[Y, X].GetValue();
                    mazeGrid.maze[Y, X].SetValue(GhostCharacter);
                }
                if (mazeGrid.maze[Y-1, X].GetValue() == '#')
                {
                    GhostDirection = "Down";
                }
                if (mazeGrid.maze[Y - 1, X].GetValue() == '#')
                {
                    HandleGhostCollision();
                }
            }
            else if (GhostDirection == "Down")
            {
                if (mazeGrid.maze[Y + 1, X].GetValue() != '#')
                {
                    mazeGrid.maze[Y, X].SetValue(PreviosItem);
                    Y++;
                    PreviosItem = mazeGrid.maze[Y, X].GetValue();
                    mazeGrid.maze[Y, X].SetValue(GhostCharacter);
                }
                if (mazeGrid.maze[Y+1, X].GetValue() == '#')
                {
                    GhostDirection = "Up";
                }
                if (mazeGrid.maze[Y + 1, X].GetValue() == '#')
                {
                    HandleGhostCollision();
                }
            }
        }
        public void Move()
        {
            ChangeDelta();
            if(Math.Floor(GetDelta())==1)
            {
                if(GhostCharacter=='H')
                {
                    MoveHorizontal(mazeGrid); 
                }
                else if (GhostCharacter == 'V')
                {
                    MoveVertical(mazeGrid);
                }
                SetDeltaZero();
            }
        }
        public int GenerateRandom()
        {
            Random rand = new Random();
            return rand.Next(1,23);
        }
        public void HandleGhostCollision()
        {
            mazeGrid.maze[Y, X].SetValue(PreviosItem);

            X = GenerateRandom();
            Y =X; 

        }
        public void MoveSmart(Cell pacmanLocation)
        {
            double minDistance = double.MaxValue;
            string minDirection = "";

            // Check each possible direction and calculate the distance to the pacmanLocation
            if (mazeGrid.maze[Y, X - 1].GetValue() != '#')
            {
                double distance = CalculateDistance(mazeGrid.maze[Y, X - 1], pacmanLocation);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minDirection = "Left";
                }
            }

            if (mazeGrid.maze[Y, X + 1].GetValue() != '#')
            {
                double distance = CalculateDistance(mazeGrid.maze[Y, X + 1], pacmanLocation);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minDirection = "Right";
                }
            }

            if (mazeGrid.maze[Y - 1, X].GetValue() != '#')
            {
                double distance = CalculateDistance(mazeGrid.maze[Y - 1, X], pacmanLocation);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minDirection = "Up";
                }
            }

            if (mazeGrid.maze[Y + 1, X].GetValue() != '#')
            {
                double distance = CalculateDistance(mazeGrid.maze[Y + 1, X], pacmanLocation);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minDirection = "Down";
                }
            }

            SetDirection(minDirection);
            Move();
        }
        double CalculateDistance(Cell current,Cell pacmanLocation)
        {
            int xDistance = Math.Abs(current.GetX() - pacmanLocation.GetX());
            int yDistance = Math.Abs(current.GetY() - pacmanLocation.GetY());
            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
        }
    }
}
