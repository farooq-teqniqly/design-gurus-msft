using System.Runtime.InteropServices;
using DesignGurusMsft.Lib;
using FluentAssertions;

namespace DesignGurusMsft.Tests;

public class ProblemTests
{
    [Theory]
    [InlineData("abc", "abcd", false)]
    [InlineData("dog", "dog", false)]
    [InlineData("good", "good", true)]
    [InlineData("daug", "audg", false)]
    [InlineData("doog", "oodd", false)]
    [InlineData("dood", "oood", false)]
    public void AreBuddyStrings_Returns_Expected_Result(string first, string second, bool expectedResult)
    {
        Problems.AreBuddyStrings(first, second).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(null, "a")]
    [InlineData("a", null)]
    [InlineData(null, null)]
    [InlineData("", "a")]
    [InlineData("a", "")]
    [InlineData("", "")]
    [InlineData("  ", "a")]
    [InlineData("a", "  ")]
    [InlineData("  ", "  ")]
    public void AreBuddyStrings_When_First_Or_Second_String_Is_Null_Throws(string first, string second)
    {
        var act = () => Problems.AreBuddyStrings(first, second);
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData(new int[]{ 0, 0, 1, 0, 1, 0, 0 }, 2, true)]
    [InlineData(new int[]{ 0, 0, 0, 0, 0, 0, 0 }, 1, true)]
    [InlineData(new int[] { 1, 0, 0, 0, 0, 1 }, 2, false)]
    [InlineData(new[] { 0, 0, 1, 0, 0 }, 1, true)]
    [InlineData(new[] { 0 }, 1, true)]
    [InlineData(new[] { 1 }, 1, false)]
    [InlineData(new int[] {}, 1, false)]
    public void CanPlantFlowers_Returns_Expected_Resul(int[] input, int flowersToPlant, bool expectedResult)
    {
        Problems.CanPlantFlowers(input, flowersToPlant).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-2)]
    public void CanPlantFlowers_When_Flowers_To_Plant_Less_Than_One_Throws(int flowersToPlant)
    {
        var act = () => Problems.CanPlantFlowers([], flowersToPlant);
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void CanPlantFlowers_When_FlowerBed_Null_Throws()
    {
        var act = () => Problems.CanPlantFlowers(null!, 1);
        act.Should().Throw<ArgumentNullException>();
    }
}
