namespace ConsoleApp
{
    public interface IRover
    {
        void SpinLeft();
        void SpinRight();
        void MoveForward();
        void ExecuteInstructions(string instructions);
        void Deploy(string position, int xMax, int yMax, int xMin, int yMin);
    }
}
