using System.Diagnostics;

public static class Algorithms
{
    public static void Run()
    {
        Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15}{5,15}{6,15}", "n", "alg1-count", "alg2-count", "alg3-count",
            "alg1-time", "alg2-time", "alg3-time");
        Console.WriteLine("{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}{0,15}", "----------");

        //Loop de teste. O 'n' size cresce de 0 a 15000, de 1000 em 1000
        for (int n = 0; n < 15001; n += 1000)
        {
            int count1 = Algorithm1(n);
            int count2 = Algorithm2(n);
            int count3 = Algorithm3(n);

            //mede o tempo médio de execução em millisegundos, repetindo 10 vezes
            double time1 = Time(Algorithm1, n, 10);
            double time2 = Time(Algorithm2, n, 10);
            double time3 = Time(Algorithm3, n, 10);
            Console.WriteLine("{0,15}{1,15}{2,15}{3,15}{4,15:0.00000}{5,15:0.00000}{6,15:0.00000}", n, count1, count2,
                count3, time1, time2,
                time3);
        }
    }

    private static double Time(Func<int, int> algorithm, int input, int times)
    {//função auxiliar que mede o tempo médio que um algoritimo leva para executar
        var sw = Stopwatch.StartNew();
        for (var i = 0; i < times; ++i)
        {
            algorithm(input);
        }

        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm1(int size)
    {//Considerações ao Big O. No loop principal a condição de parada depende diretamente de size (n)
        var count = 0;
        for (var i = 0; i < size; ++i) //o ofr loop executa size vezes
            count += 1;// executa uma quantidade constante de trabalho
        //o crescimento: o numero de ooperções é diretamene proporcional a (n) 
        return count;
        //conclusão: o número de passos cresce linear com o tamamnho da entrada, portanto O(n)
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm2(int size)
    {
        //conclusão //considerações ao Big O. Tempo quadrático. O trabalho cresce com o quadrado do do tamanho da entrada 'size' logo O(n^2)
        var count = 0;
        //ocorre loop aninhados. O loop interno executa size vezes , para cada uma das size vezes do loop externo
        //total de execuções = size * size
        for (var i = 0; i < size; ++i)
            for (var j = 0; j < size; ++j)
                count += 1;

        return count; //retorna 'size * size' (n^2)
    }

    /// <summary>
    /// The count variable is keeping track of the amount
    /// of work done in the function.  When the function is 
    /// done the count is returned.
    /// </summary>
    /// <param name="size">the amount of work to do</param>
    private static int Algorithm3(int size)
    { //'size' é o n
        var count = 0;
        var start = 0;
        var end = size - 1;
        while (start <= end)
        {//o loop continua enquanto a seção de busca for verdadeira ou válida
            var middle = (end - start) / 2 + start;//reduz a busca pela metade
            start = middle + 1;
            count += 1;//contador
        }
        //O número de passos necessários para o loop terminar é o número de vezes que você pode dividir $n$ por 2 até chegar a 1. Isso é a definição de logaritmo de base 2 (log2n).
        //conclusão O(log n)
        return count;
    }
}

//answer 2
//Algorithm 3 is much faster and algorithm2 is much slower
//O(log n) is better than O(n) and O(n) is better than O(n^2)

//asnwer 3
//When n is small, the time for all three algorithms is very close to each other.
//Realizing that these are in milliseconds, the amount of time to see the result for Algorithm2 when n is large will start to approach 1 second unlike the other 2 functions.
//However, when n is small, no difference is seen by the user.