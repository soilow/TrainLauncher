using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Xunit;
using Xunit.Abstractions;

namespace Lab1.Tests;

public static class TestHelper
{
    public static void ExpectSuccess(LaunchResult result, ITestOutputHelper testOutputHelper)
    {
        LaunchResult.Success successResult = Assert.IsType<LaunchResult.Success>(result);
        testOutputHelper.WriteLine($"Time elapsed: {successResult.TimeElapsed}");
    }

    public static void ExpectFailure(LaunchResult result)
    {
        LaunchResult.Failure failureResult = Assert.IsType<LaunchResult.Failure>(result);
    }
}