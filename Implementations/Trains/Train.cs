namespace Itmo.ObjectOrientedProgramming.Lab1.Implementations.Trains;

public class Train
{
    public double Weight { get; init; }

    public double MaxAllowableForce { get; init; }

    public int Accuracy { get; init; }

    public double Speed { get; set; } = 0;

    public double Acceleration { get; set; } = 0;

    public Train(double weight, double maxAllowableForce, int accuracy)
    {
        this.Weight = weight;
        this.MaxAllowableForce = maxAllowableForce;
        this.Accuracy = accuracy;
    }

    public bool IsMovementPossible()
    {
        if (Speed == 0 && Acceleration == 0)
        {
            return false;
        }

        if (Speed < 0)
        {
            return false;
        }

        return true;
    }
}