using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Implementations.Sections;

public class StationSection : ISection
{
    private readonly int _maxAllowableSpeed;

    public StationSection(int maxAllowableSpeed)
    {
        _maxAllowableSpeed = maxAllowableSpeed;
    }

    public LaunchResult TryToPass(Train train)
    {
        if (train.Speed > _maxAllowableSpeed)
        {
            return new LaunchResult.Failure();
        }
        else
        {
            return new LaunchResult.Success(0);
        }
    }
}