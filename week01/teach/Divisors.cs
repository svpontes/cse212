public static class Divisors
{
    /// <summary>
    /// Entry point for the Divisors class
    /// </summary>
    public static void Run()
    {//metodo Run
        List<int> list = FindDivisors(80);
        Console.WriteLine("<List>{" + string.Join(", ", list) + "}"); // <List>{1, 2, 4, 5, 8, 10, 16, 20, 40}
        List<int> list1 = FindDivisors(79);
        Console.WriteLine("<List>{" + string.Join(", ", list1) + "}"); // <List>{1}
    }

    /// <summary>
    /// Create a list of all divisors for a number including 1
    /// and excluding the number itself. Modulo will be used
    /// to test divisibility.
    /// </summary>
    /// <param name="number">The number to find the divisor</param>
    /// <returns>List of divisors</returns>
    private static List<int> FindDivisors(int number)//numero 80 será utilizado
    {//metodo FindDivisors(parÂmetros numeros inteiros)
        List<int> results = new(); //cria uma nova lista vazia chamada de results

        for (int i = 1; i < number; i++)//atribui o numero 1 á variável i afim de incluir-lo na lista de divisores. Até que i seja menor que o numero (80); i++ valor de i +1 até chegar ao 80 onde para o loop
        {

            //% retorna o resto da divisão, e se o resto for 0 o que significa uma divisão exata, então é divisor
            if (number % i == 0)
            {

                results.Add(i); //adiciona o divisor à lista resultados
            }
        }

        return results;
    }
}