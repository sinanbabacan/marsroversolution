using System;

namespace ConsoleApp
{
    public class Rover : IRover
    {
        public Position Position;

        private Plateau _plateau;

        public Rover(Plateau plateau)
        {
            _plateau = plateau;
        }

        public Rover(Plateau plateau, string position) : this(plateau)
        {
            this.Deploy(position, plateau.XMax, plateau.YMax, plateau.XMin, plateau.YMin);
        }

        public void ExecuteInstructions(string instructions)
        {
            foreach (char instruction in instructions)
            {
                switch (instruction)
                {
                    case 'L':
                        SpinLeft();
                        break;
                    case 'R':
                        SpinRight();
                        break;
                    case 'M':
                        MoveForward();
                        break;
                }
            }
        }

        public void MoveForward()
        {
            switch (Position.Direction)
            {
                case Direction.N:

                    if (Position.Y + 1 <= _plateau.YMax)
                    {
                        Position.Y += 1;
                    }

                    break;

                case Direction.S:

                    if (Position.Y - 1 >= _plateau.YMin)
                    {
                        Position.Y -= 1;
                    }

                    break;

                case Direction.E:

                    if (Position.X + 1 <= _plateau.XMax)
                    {
                        Position.X += 1;
                    }

                    break;

                case Direction.W:

                    if (Position.X - 1 >= _plateau.XMin)
                    {
                        Position.X -= 1;
                    }

                    break;
            }
        }

        public void SpinLeft()
        {
            switch (Position.Direction)
            {
                case Direction.N:
                    Position.Direction = Direction.W;
                    break;

                case Direction.S:
                    Position.Direction = Direction.E;
                    break;

                case Direction.E:
                    Position.Direction = Direction.N;
                    break;

                case Direction.W:
                    Position.Direction = Direction.S;
                    break;
            }
        }

        public void SpinRight()
        {
            switch (Position.Direction)
            {
                case Direction.N:
                    Position.Direction = Direction.E;
                    break;

                case Direction.S:
                    Position.Direction = Direction.W;
                    break;

                case Direction.E:
                    Position.Direction = Direction.S;
                    break;

                case Direction.W:
                    Position.Direction = Direction.N;
                    break;
            }
        }

        public void Deploy(string position, int xMax, int yMax, int xMin, int yMin)
        {
            string[] xyz = position.Split(" ");

            int x = int.Parse(xyz[0]);

            if (x > xMax)
            {
                throw new PositionException("Rover X coordinate higher from plateau xMax coordinate");
            }

            if (x < xMin)
            {
                throw new PositionException("Rover X coordinate lower from plateau xMin coordinate");
            }

            int y = int.Parse(xyz[1]);

            if (y > yMax)
            {
                throw new PositionException("Rover Y coordinate higher from plateau yMax coordinate");
            }

            if (y < yMin)
            {
                throw new PositionException("Rover Y coordinate lower from plateau yMin coordinate");
            }

            Direction direction = Enum.Parse<Direction>(xyz[2]);

            Position = new Position(x, y, direction);
        }

        public string PositionResult()
        {
            return Position.ToString();
        }
    }
}
