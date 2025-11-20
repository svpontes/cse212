public static class IsPalindrome
{
    public static bool Ispalindrome(string text)
    {
        var stack = new Stack<char>();

        // Empilha os caracteres
        foreach (var letter in text)
            stack.Push(letter);

        // Desempilha para formar o texto invertido
        var reversed = "";
        while (stack.Count > 0)
            reversed += stack.Pop();

        // Compara e retorna o resultado
        return text == reversed;
    }
}
