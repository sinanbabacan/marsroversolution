namespace ConsoleApp
{
    public interface IRover
    {
        void SpinLeft();
        void SpinRight();
        void MoveForward();
        void ExecuteInstructions(string instructions);
    }
}
