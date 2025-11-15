using System.Reflection.Metadata;

public static class UniqueLetters
{
    public static void Run()
    {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrsttttuvwxtttyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string

        //test with AreUniqueLetters_Bool(string text) for short strings
        Console.WriteLine("=======Approach for Short Strings ========");
        var test4 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters_Bool(test4));

        var test5 = "abcdefghjiklanhhhopqrstuttttvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters_Bool(test5));

        var test6 = "";
        Console.WriteLine(AreUniqueLetters_Bool(test6)); // Expect True because its an empty string

    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    // <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>
    private static bool AreUniqueLetters(string text)
    {

        // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency

        //The O(n^2) happened because there are two loops to compare and find ?

        //instead we must have one loop e keep a set of carachteres already seen
        //if the character exists in the set we have a duplicate - thats return false
        //if not we add to the set

        //The best approach is HashSet<char> /WHY: 1- methods Add and Contais fro HashSet are O(1)
        //2- Advantage: efficiency to identify duplicates when looping 
        /*

        for (var i = 0; i < text.Length; ++i)
        {
            for (var j = 0; j < text.Length; ++j)
            {
                // Don't want to compare to yourself ... that will always result in a match
                if (i != j && text[i] == text[j])
                    return false;
            }
        }*/
        //option 1: much better
        if (string.IsNullOrEmpty(text))
            return true;

        var seen = new HashSet<char>(text.Length);
        foreach (var ch in text) //we loop throught the string once O(n)
        {
            if (seen.Contains(ch))
                return false;
            seen.Add(ch);
        }

        return true;
    }

    //option to short strings
    //loop through the whole string even find duplicates at the beggning
    private static bool AreUniqueLetters_Bool(string text)
    {
        if (string.IsNullOrEmpty(text))
            return true;

        var unique = new HashSet<char>(text);
        return unique.Count == text.Length;
    }
    
}

/*
UniqueLetters.cs
This code will determine if a string has all unique letters. For example, "abcdefg" has unique letters but "abccdefg" does not because the "c" is repeated more than once. 
The code is implemented using loops which results in an O(n2) performance.
Answer the question together: How can unique letter method be written with O(n) performance using a set? 
As you answer this question, talk about the behavior, purpose and/or performance of a set to help you arrive at an answer.
After you think you know how to solve the problem (take no more than five minutes), compare your approach to the solution below.

*/