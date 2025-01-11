using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Implementations.Sections;

public class ForceMagneticPathSection : ISection
{
    private readonly int _pathLenght;
    private readonly int _pathForce;
    private double _appliedForce;

    public ForceMagneticPathSection(int pathLenght, int pathForce)
    {
        this._pathLenght = pathLenght;
        this._pathForce = pathForce;
    }

    public LaunchResult TryToPass(Train train)
    {
        if (!TryToApplyForceToTrain(train))
        {
            return new LaunchResult.Failure();
        }

        double distanceCovered = 0;
        double incrementalDistance = 0;
        double elapsedTime = 0;

        while (distanceCovered < _pathLenght)
        {
            train.Speed = train.Speed + (_appliedForce * train.Accuracy);
            incrementalDistance = train.Speed * train.Accuracy;
            distanceCovered += incrementalDistance;
            elapsedTime += incrementalDistance / train.Speed;

            if (!train.IsMovementPossible())
            {
                return new LaunchResult.Failure();
            }
        }

        return new LaunchResult.Success(elapsedTime);
    }

    private bool TryToApplyForceToTrain(Train train)
    {
        if (_pathForce > train.MaxAllowableForce)
        {
            return false;
        }
        else
        {
            _appliedForce = _pathForce / train.Weight;

            return true;
        }
    }
}