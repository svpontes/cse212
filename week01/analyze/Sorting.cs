public static class Sorting
{
    public static void Run()
    {
        var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };
        SortArray(numbers);
        Console.Out.WriteLine("int[]{{{0}}}", string.Join(", ", numbers)); //int[]{1, 2, 3, 4, 6, 8, 9}
    }

    private static void SortArray(int[] data)
    {//considerando os valores de numbers = { 3, 2, 1, 6, 4, 9, 8 }

        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--)

        {
            for (var swapPos = 0; swapPos < sortPos; ++swapPos)
            {
                if (data[swapPos] > data[swapPos + 1])
                {
                    (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                }
            }
        }
    }
}

//Análise Big O
/*

Tamanho da entrada: (n) = data.Length
Trabalho total = soma das execuções de for (var swapPos = 0; swapPos < sortPos; ++swapPos) laço interno. sortPos é executado por swapPos varias vezes e o valor de sortPos muda a cada rodada
equação fica n^2/2
aplicando regras do Big O:

identificar o termo dominante - quando o tamanho do array(n) aumentar o termo n2 domina. ex. se n = 1000, n2 = 1.000.0000
Ignorar coeficiente constantes: 1/2
Termo final é n^2 logo O(n^2)

*/