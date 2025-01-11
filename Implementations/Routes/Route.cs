using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Implementations.Routes;

public class Route
{
    private readonly List<ISection> _road = new List<ISection>();
    private readonly int _maxAllowableSpeed;
    private double _totalTime = 0;

    public Route(int maxAllowableSpeed)
    {
        this._maxAllowableSpeed = maxAllowableSpeed;
    }

    public LaunchResult Launch(Train train)
    {
        // Add "station" with route max allowable speed to stop the train
        _road.Add(new StationSection(_maxAllowableSpeed));

        foreach (ISection section in _road)
        {
            LaunchResult result = section.TryToPass(train);

            if (result is LaunchResult.Failure)
            {
                return new LaunchResult.Failure();
            }

            if (result is LaunchResult.Success s)
            {
                _totalTime += s.TimeElapsed;
            }
        }

        return new LaunchResult.Success(_totalTime);
    }

    public void AddSection(ISection section) => _road.Add(section);
}