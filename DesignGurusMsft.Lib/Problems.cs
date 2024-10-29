namespace DesignGurusMsft.Lib;

public class Problems
{
    /// <summary>
    /// Determines if two strings are buddy strings.
    /// Buddy strings are strings that can be made equal by swapping exactly one pair of characters in one of the strings.
    /// </summary>
    /// <param name="first">The first string to compare.</param>
    /// <param name="second">The second string to compare.</param>
    /// <returns>True if the strings are buddy strings; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either <paramref name="first"/> or <paramref name="second"/> is null or whitespace.</exception>
    /// <exception cref="ArgumentException">Thrown when the lengths of <paramref name="first"/> and <paramref name="second"/> are not equal.</exception>
    public static bool AreBuddyStrings(string first, string second)
    {
        if (string.IsNullOrWhiteSpace(first))
        {
            throw new ArgumentNullException(nameof(first));
        }

        if (string.IsNullOrWhiteSpace(second))
        {
            throw new ArgumentNullException(nameof(second));
        }

        // case 1: strings are different lengths
        if (first.Length != second.Length)
        {
            return false;
        }

        if (string.Compare(first, second, StringComparison.InvariantCultureIgnoreCase) == 0)
        {
            // case 2: strings are same, needs to be at least one duplicate char.
            var dupes = new HashSet<char>();

            foreach (var c in first)
            {
                if (!dupes.Add(c))
                {
                    return true;
                }
            }

            return false;
        }

        // case 3: strings are different; need to differ in 2 and only 2 positions and after swap
        // string first should equal string second.

        var differences = new List<int>();

        for (var i = 0; i < first.Length; i++)
        {
            if (first[i] != second[i])
            {
                differences.Add(i);
            }

            if (differences.Count > 2)
            {
                return false;
            }
        }

        if (differences.Count < 2)
        {
            return false;
        }

        return first[differences[0]] == second[differences[1]] &&
            first[differences[1]] == second[differences[0]];
    }
}
