using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList : IEnumerable<int>
{
    // Internal node structure for the doubly linked list.
    private class Node
    {
        public int Data;      // The stored value.
        public Node? Next;    // Pointer to the next node.
        public Node? Prev;    // Pointer to the previous node.

        public Node(int data) => Data = data;
    }

    private Node? _head; // Points to the first node in the list.
    private Node? _tail; // Points to the last node in the list.

    // Inserts a new node at the end (tail) of the list.
    public void InsertTail(int value)
    {
        var newNode = new Node(value);

        // Case 1: The list is currently empty.
        if (_tail is null)
        {
            _head = _tail = newNode;
        }
        // Case 2: The list has at least one element.
        else
        {
            newNode.Prev = _tail;   // Link new node backwards to old tail.
            _tail.Next = newNode;   // Link old tail forward to new node.
            _tail = newNode;        // Update tail reference.
        }
    }

    // Removes the first node (head) of the list.
    public void RemoveHead()
    {
        // Nothing to remove if the list is empty.
        if (_head is null) return;

        // Case 1: Only one node exists.
        if (_head == _tail)
        {
            _head = _tail = null;
        }
        // Case 2: Multiple nodes exist.
        else
        {
            Node? next = _head.Next;
            _head.Next = null;  // Disconnect removed node.
            next!.Prev = null;  // New head must have no previous link.
            _head = next;
        }
    }

    // Removes the last node (tail) of the list.
    public void RemoveTail()
    {
        // Nothing to remove.
        if (_tail is null) return;

        // Case 1: Only one element exists.
        if (_head == _tail)
        {
            _head = _tail = null;
        }
        // Case 2: Multiple nodes exist.
        else
        {
            Node? prev = _tail.Prev;
            _tail.Prev = null;  // Disconnect removed tail.
            prev!.Next = null;  // New tail must not point forward.
            _tail = prev;
        }
    }

    // Removes the first node that matches the given value.
    public void Remove(int value)
    {
        Node? curr = _head;

        // Traverse until a match is found.
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // Case 1: Node is the head.
                if (curr == _head)
                {
                    RemoveHead();
                }
                // Case 2: Node is the tail.
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Case 3: Node is in the middle.
                else
                {
                    curr.Prev!.Next = curr.Next; // Link previous node forward.
                    curr.Next!.Prev = curr.Prev; // Link next node backward.

                    // Optionally clean references to avoid memory retention.
                    curr.Next = curr.Prev = null;
                }

                return; // Stop after removing the first match.
            }

            curr = curr.Next; // Continue traversal.
        }
    }

    // Replaces all occurrences of oldValue with newValue.
    public void Replace(int oldValue, int newValue)
    {
        for (var curr = _head; curr is not null; curr = curr.Next)
        {
            if (curr.Data == oldValue)
                curr.Data = newValue;
        }
    }

    // Returns a reverse iterator, starting from the tail.
    public IEnumerable<int> Reverse()
    {
        for (var curr = _tail; curr is not null; curr = curr.Prev)
            yield return curr.Data;
    }

    // Default forward iterator implementation.
    public IEnumerator<int> GetEnumerator()
    {
        for (var curr = _head; curr is not null; curr = curr.Next)
            yield return curr.Data;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
