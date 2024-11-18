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

    /// <summary>
    /// Determines if flowers can be planted in a flower bed.
    /// </summary>
    /// <param name="flowerBed">The array representing the flower bed where 0 represents an empty spot and 1 represents a planted flower.</param>
    /// <param name="flowersToPlant">The number of flowers to plant.</param>
    /// <returns>True if the flowers can be planted in the flower bed; otherwise, false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="flowerBed"/> is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="flowersToPlant"/> is less than 1.</exception>
    public static bool CanPlantFlowers(int[] flowerBed, int flowersToPlant)
    {
        ArgumentNullException.ThrowIfNull(flowerBed);
        ArgumentOutOfRangeException.ThrowIfLessThan(flowersToPlant, 1);

        var leftToPlant = flowersToPlant;

        for (var i = 0; i < flowerBed.Length; i += 2)
        {
            if (leftToPlant == 0)
            {
                return true;
            }

            if (flowerBed[i] == 1)
            {
                continue;
            }

            if (i > 0 && flowerBed[i - 1] == 1)
            {
                continue;
            }

            if (i < flowerBed.Length - 1 && flowerBed[i + 1] == 1)
            {
                continue;
            }

            flowerBed[i] = 1;
            leftToPlant--;
        }

        return leftToPlant == 0;
    }

    /// <summary>
    /// Determines the minimum frequency of the letters 'b', 'a', 'l', 'o', and 'n' in the given input string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>The minimum frequency of the letters 'b', 'a', 'l', 'o', and 'n' in the input string.</returns>
    public static int MaxBalloons(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentNullException(nameof(input));
        }

        var frequencies = new Dictionary<char, int>()
        {
            { 'b', 0 },
            { 'a', 0 },
            { 'l', 0 },
            { 'o', 0 },
            { 'n', 1 }
        };

        foreach (var letter in input.ToLowerInvariant())
        {
            if (!frequencies.ContainsKey(letter))
            {
                continue;
            }

            frequencies[letter] += 1;
        }

        var minFrequency = int.MaxValue;

        foreach (var pair in frequencies)
        {
            var adjustedFrequency = pair.Value;

            if (pair.Key is 'l' or 'o')
            {
                adjustedFrequency /= 2;
            }

            if (adjustedFrequency < minFrequency)
            {
                minFrequency = adjustedFrequency;
            }
        }

        return minFrequency;
    }
}
