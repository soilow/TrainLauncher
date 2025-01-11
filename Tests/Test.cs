using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Routes;
using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Sections;
using Itmo.ObjectOrientedProgramming.Lab1.Implementations.Trains;
using Itmo.ObjectOrientedProgramming.Lab1.Results;
using Xunit;
using Xunit.Abstractions;

namespace Lab1.Tests;

public class Test
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        var route = new Route(100);
        var train = new Train(100, 50000, 1);

        route.AddSection(new ForceMagneticPathSection(100, 200));
        route.AddSection(new MagneticPathSection(100));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectSuccess(result, _testOutputHelper);
    }

    [Fact]
    public void Test2()
    {
        var route = new Route(100);
        var train = new Train(100, 50000, 1);

        route.AddSection(new ForceMagneticPathSection(100, 40000));
        route.AddSection(new MagneticPathSection(100));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectFailure(result);
    }

    [Fact]
    public void Test3()
    {
        var route = new Route(100);
        var train = new Train(100, 50000, 1);

        route.AddSection(new ForceMagneticPathSection(100, 500));
        route.AddSection(new MagneticPathSection(100));
        route.AddSection(new StationSection(100));
        route.AddSection(new MagneticPathSection(200));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectSuccess(result, _testOutputHelper);
    }

    [Fact]
    public void Test4()
    {
        var route = new Route(100);
        var train = new Train(100, 50000, 1);

        route.AddSection(new ForceMagneticPathSection(100, 20000));
        route.AddSection(new StationSection(50));
        route.AddSection(new MagneticPathSection(100));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectFailure(result);
    }

    [Fact]
    public void Test5()
    {
        var route = new Route(20);
        var train = new Train(100, 50000, 1);

        route.AddSection(new ForceMagneticPathSection(100, 2000));
        route.AddSection(new MagneticPathSection(100));
        route.AddSection(new StationSection(100));
        route.AddSection(new MagneticPathSection(100));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectFailure(result);
    }

    [Fact]
    public void Test6()
    {
        var route = new Route(100);
        var train = new Train(100, 50000, 7);

        route.AddSection(new ForceMagneticPathSection(100, 200));
        route.AddSection(new MagneticPathSection(100));
        route.AddSection(new ForceMagneticPathSection(100, -140));
        route.AddSection(new StationSection(20));
        route.AddSection(new MagneticPathSection(100));
        route.AddSection(new ForceMagneticPathSection(100, 600));
        route.AddSection(new MagneticPathSection(100));
        route.AddSection(new ForceMagneticPathSection(100, -250));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectSuccess(result, _testOutputHelper);
    }

    [Fact]
    public void Test7()
    {
        var route = new Route(100);
        var train = new Train(100, 50000, 1);

        route.AddSection(new MagneticPathSection(100));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectFailure(result);
    }

    [Fact]
    public void Test8()
    {
        int x = 100;
        int y = 300;

        var route = new Route(100);
        var train = new Train(100, 50000, 1);

        route.AddSection(new ForceMagneticPathSection(x, y));
        route.AddSection(new ForceMagneticPathSection(x, -2 * y));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectFailure(result);
    }

    [Fact]
    public void Test9()
    {
        var route = new Route(100);
        var train = new Train(937, 50000, 7);

        route.AddSection(new ForceMagneticPathSection(47, 40));
        route.AddSection(new MagneticPathSection(39));
        route.AddSection(new StationSection(40));

        LaunchResult result = route.Launch(train);

        TestHelper.ExpectSuccess(result, _testOutputHelper);
    }
}