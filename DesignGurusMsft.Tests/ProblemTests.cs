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
}
