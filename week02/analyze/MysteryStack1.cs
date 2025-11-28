public static class MysteryStack1
{//Função InverterTexto(texto):
    public static string Run(string text)
    {
        var stack = new Stack<char>();//Criar uma pilha vazia chamada pilha
        foreach (var letter in text)// Para cada caractere letra em texto:
            stack.Push(letter);//Empilhar (Push) letra na pilha

        var result = "";//Criar uma string vazia chamada resultado
        while (stack.Count > 0)//Enquanto a pilha não estiver vazia:
            result += stack.Pop(); //Remover(Pop) o elemento do topo da pilha
                                   //Concatenar esse elemento ao final de resultado
        return result;
    }
}

/*
Determine the output of the function if the input text is equal to the following:
racecar -  the result is "rececar" - Palindrome
stressed - the result is "desserts2"
a nut for a jar of tuna - the result is "a nut for a jar of tuna" - Palindrome
*/