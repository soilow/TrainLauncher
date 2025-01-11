using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Implementations.Sections;

public class MagneticPathSection : ISection
{
    private readonly int _pathLenght;

    public MagneticPathSection(int pathLenght)
    {
        this._pathLenght = pathLenght;
    }

    public LaunchResult TryToPass(Train train)
    {
        double distanceCovered = 0;
        double incrementalDistance = 0;
        double timeElapsed = 0;

        while (distanceCovered < _pathLenght)
        {
            if (!train.IsMovementPossible())
            {
                return new LaunchResult.Failure();
            }

            incrementalDistance = train.Speed * train.Accuracy;
            distanceCovered += incrementalDistance;
            timeElapsed += incrementalDistance / train.Speed;
        }

        return new LaunchResult.Success(timeElapsed);
    }
}