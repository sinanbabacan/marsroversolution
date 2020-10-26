using System;

namespace ConsoleApp
{
    public class Rover : IRover
    {
        private Plateau _plateau;
        private Position _position;

        public Rover(string position, Plateau plateau)
        {
            string[] vs = position.Split(" ");

            _position = new Position(int.Parse(vs[0]), int.Parse(vs[1]), Enum.Parse<Direction>(vs[2]));

            _plateau = plateau;
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
            switch (_position.Direction)
            {
                case Direction.N:

                    if (_position.Y + 1 <= _plateau.Ymax)
                    {
                        _position.Y = _position.Y + 1;
                    }

                    break;

                case Direction.S:

                    if (_position.Y - 1 >= _plateau.Ymin)
                    {
                        _position.Y = _position.Y - 1;
                    }

                    break;

                case Direction.E:

                    if (_position.X + 1 <= _plateau.Xmax)
                    {
                        _position.X = _position.X + 1;
                    }

                    break;

                case Direction.W:

                    if (_position.X - 1 >= _plateau.Xmin)
                    {
                        _position.X = _position.X - 1;
                    }

                    break;
            }
        }

        public void SpinLeft()
        {
            switch (_position.Direction)
            {
                case Direction.N:
                    _position.Direction = Direction.W;
                    break;

                case Direction.S:
                    _position.Direction = Direction.E;
                    break;

                case Direction.E:
                    _position.Direction = Direction.N;
                    break;

                case Direction.W:
                    _position.Direction = Direction.S;
                    break;
            }
        }

        public void SpinRight()
        {
            switch (_position.Direction)
            {
                case Direction.N:
                    _position.Direction = Direction.E;
                    break;

                case Direction.S:
                    _position.Direction = Direction.W;
                    break;

                case Direction.E:
                    _position.Direction = Direction.S;
                    break;

                case Direction.W:
                    _position.Direction = Direction.N;
                    break;
            }
        }

        public string Position()
        {
            return _position.ToString();
        }
    }
}
