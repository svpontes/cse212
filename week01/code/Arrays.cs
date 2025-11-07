public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        /*
        steps:
        1- Validate the parameter int length (must be a positive number)
            where if length <=0 return 0
        2- Validate parameter double number (NaN and IsInfinity)
            where if double.IsNaN(number) and double.IsInfinity(number) an exception will be trhowned
        3 - create a new array type double (name of the array: result) to get the results
        4 - When a number and length are provided in the main of the program where the function will be evoked and a for loop will fill the array
        5 - return the result 
        */

        //step 2
        if (length <= 0)
        {
            return new double[0];
        }


        if (double.IsNaN(number) || double.IsInfinity(number))
        {
            throw new ArgumentException("Parameter 'number', must be a finite number", nameof(number));
        }

        //step 3
        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); //(i+1) multiplication starts from the first multiple number
        }
        //step 4
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /*
        steps:
        1 - Understand  the result:
            data = [1, 2, 3, 4, 5, 6, 7, 8, 9], int amount = 3 
            get and store data Last 3 itens = [7, 8, 9]
            get and store data other itens = [1, 2, 3, 4, 5, 6]
            clear list data = []
            add Last 3 itens => data = [7, 8, 9]
            add other itens => data = [1, 2, 3, 4, 5, 6]
            result = [7, 8, 9, 1, 2, 3, 4, 5, 6] 
        
        2 - use getRange method to get the amount of 3 last itens and store them in some List (last3Itens)
        3 - use getRange() method to get the other itens and store them in some List (otherItens)
        4 - clear and re-organize the items as result showned
        5 - use addRange() to add the Last 3 itens => data = [7, 8, 9] to result list
        6 - use addRange() to add the other itens => data = [1, 2, 3, 4, 5, 6] to result list
        

        */

        //get the last 3 elements. Saved in List<int> last3itens, to be used after list is clear
        List<int> last3Itens = data.GetRange(data.Count - amount, amount);

        //get the other elements. Saved in List<int> otherItens, to be used after list is clear 
        List<int> otherItens = data.GetRange(0, data.Count - amount);

        //clear and re-organize the the list
        data.Clear();

        //add the last 3 itens 
        data.AddRange(last3Itens);

        //add the other elements
        data.AddRange(otherItens);


    }
}
