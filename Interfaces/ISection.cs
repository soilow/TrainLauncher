using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Interfaces;

public interface ISection
{
    LaunchResult TryToPass(Train train);
}