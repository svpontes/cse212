/// <summary>
/// These 3 functions will (in different ways) calculate the standard
/// deviation from a list of numbers.  The standard deviation
/// is defined as the square root of the variance.  The variance is 
/// defined as the average of the squared differences from the mean.
/// </summary>
public static class StandardDeviation
{
    public static void Run()
    {
        var numbers = new[] { 600, 470, 170, 430, 300 };
        Console.WriteLine(StandardDeviation1(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation2(numbers)); // Should be 147.322 
        Console.WriteLine(StandardDeviation3(numbers)); // Should be 147.322 
    }

    private static double StandardDeviation1(int[] numbers)
    {//n é o tamanho do array numbers
        var total = 0.0;
        var count = 0;
        foreach (var number in numbers)
        { //1º foreach - loop que percorre o array number n vezes. Complexidade: O(n)
            total += number;
            count += 1;
        }

        var avg = total / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers)
        {
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }

    private static double StandardDeviation2(int[] numbers)
    {//n é o tamanho do array numbers
        var sumSquaredDifferences = 0.0;
        var countNumbers = 0;
        foreach (var number in numbers)
        {//2º foreach - loop que percorre o array number n vezes. Complexidade: O(n)
            var total = 0;
            var count = 0;
            foreach (var value in numbers)
            {
                total += value;
                count += 1;
            }

            var avg = total / count;
            sumSquaredDifferences += Math.Pow(number - avg, 2);
            countNumbers += 1;
        }

        var variance = sumSquaredDifferences / countNumbers;
        return Math.Sqrt(variance);
    }

    private static double StandardDeviation3(int[] numbers)
    { //n é o tamanho do array numbers
        var count = numbers.Length;
        var avg = (double)numbers.Sum() / count;
        var sumSquaredDifferences = 0.0;
        foreach (var number in numbers)
        { //3º foreach - loop que percorre o array number n vezes. Complexidade: O(n)
            sumSquaredDifferences += Math.Pow(number - avg, 2);
        }

        var variance = sumSquaredDifferences / count;
        return Math.Sqrt(variance);
    }
}

//standartDeviation1 O(n)+O(n)+O(1)constante
//ignorando termo dominante então fica O(n)