namespace DesignGurusMsft.Lib.DataStructures;
public class ListNode
{
    /// <summary>
    /// Gets the value of the ListNode.
    /// </summary>
    public int Value { get; }

    /// <summary>
    /// Gets or sets the next ListNode.
    /// </summary>
    public ListNode? Next { get; set; }

    /// <summary>
    /// Initializes a new instance of the ListNode class with the specified value and next ListNode.
    /// </summary>
    /// <param name="value">The value of the ListNode.</param>
    /// <param name="next">The next ListNode.</param>
    public ListNode(int value, ListNode? next = null)
    {
        Value = value;
        Next = next;
    }

    /// <summary>
    /// Reverses the order of the given ListNode.
    /// </summary>
    /// <param name="head">The head ListNode.</param>
    /// <returns>The reversed ListNode.</returns>
    public static ListNode Reverse(ListNode? head)
    {
        ListNode? previous = null;
        var current = head;

        while (current != null)
        {
            var save = current.Next;
            current.Next = previous;
            previous = current;
            current = save;
        }

        return previous!;
    }
}
