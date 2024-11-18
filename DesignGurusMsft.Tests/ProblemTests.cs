using System.Runtime.InteropServices;
using DesignGurusMsft.Lib;
using DesignGurusMsft.Lib.DataStructures;
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
    [InlineData(new[] { 0, 0, 1, 0, 0 }, 2, true)]
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

    [Fact]
    public void Can_Reverse_Linked_List_Multiple_Nodes()
    {
        var linkedList = new ListNode(2, new ListNode(4, new ListNode(6, new ListNode(8, new ListNode(10)))));
        var newHead = ListNode.Reverse(linkedList);
        newHead.Value.Should().Be(10);
        newHead.Next!.Value.Should().Be(8);
    }

    [Fact]
    public void Can_Reverse_Linked_List_Single_Node()
    {
        var linkedList = new ListNode(2);
        var newHead = ListNode.Reverse(linkedList);
        newHead.Value.Should().Be(2);
    }

    [Fact]
    public void Can_Reverse_Linked_List_Two_Nodes()
    {
        var linkedList = new ListNode(2, new ListNode(4));
        var newHead = ListNode.Reverse(linkedList);
        newHead.Value.Should().Be(4);
        newHead.Next!.Value.Should().Be(2);
    }

    [Fact]
    public void Reverse_Does_Not_Throw_When_Head_Is_Null()
    {
        ListNode.Reverse(null).Should().Be(null);
    }

    [Theory]
    [InlineData("balloonballoon", 2)]
    [InlineData("bbaall", 0)]
    [InlineData("balloonballoooon", 2)]
    [InlineData("BAlloonballoOOon", 2)]
    [InlineData("xyz", 0)]
    [InlineData("balon", 0)]
    public void MaxBalloons_Returns_Expected_Result(string input, int expectedResult)
    {
        Problems.MaxBalloons(input).Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void MaxBalloons_When_Input_Null_Throws(string input)
    {
        var act = () => Problems.MaxBalloons(input);
        act.Should().Throw<ArgumentNullException>();
    }

    [Theory]
    [InlineData("balloon","balloonballoon", 2)]
    [InlineData("balloon", "bbaall", 0)]
    [InlineData("balloon", "BAlloonballoOOon", 1)]
    [InlineData("balloon", "xyz", 0)]
    [InlineData("balloon", "balon", 0)]
    [InlineData("riddle", "rriddleriddler", 2)]
    [InlineData("riddle", "ridd", 0)]

    public void MaxOccurrencesOfWord_Returns_Expected_Result(string word, string input, int expectedResult)
    {
        Problems.MaxOccurrencesOfWord(word, input).Should().Be(expectedResult);
    }
}
