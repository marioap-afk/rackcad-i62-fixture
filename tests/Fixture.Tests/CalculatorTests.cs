using Fixture.Lib;
using Xunit;

namespace Fixture.Tests;

public class CalculatorTests
{
    [Fact]
    public void AddSumsTwoIntegers() => Assert.Equal(5, Calculator.Add(2, 3));
}
