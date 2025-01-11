namespace Itmo.ObjectOrientedProgramming.Lab1.Results;

public abstract record LaunchResult()
{
    public sealed record Success(double TimeElapsed) : LaunchResult;

    public sealed record Failure() : LaunchResult;
}