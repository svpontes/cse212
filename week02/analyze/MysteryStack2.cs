public static class MysteryStack2
{
    //função invert texto 2
    private static bool IsFloat(string text)
    {
        return float.TryParse(text, out _);
    }

    public static float Run(string text)
    {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' '))
        {
            if (item == "+" || item == "-" || item == "*" || item == "/")
            {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+")
                {
                    res = op1 + op2;
                }
                else if (item == "-")
                {
                    res = op1 - op2;
                }
                else if (item == "*")
                {
                    res = op1 * op2;
                }
                else
                {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item))
            {
                stack.Push(float.Parse(item));
            }
            else if (item == "")
            {
            }
            else
            {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}

/*resultado results:

5 3 7 + *

pilha 7,3,  3+7 = 10, 5
10*5
= 50

6 2 + 5 3 - /
2+6 8, 5-3 2 push 2, 8
por 2 e 8 8/2 = 4 push



*/
/*
Função AvaliarExpressaoPosFixa(texto):

    Criar uma pilha vazia chamada pilha

    Dividir o texto em itens separados por espaço

    Para cada item da lista:

        Se o item for um operador (+, -, *, /):

            Se houver menos de 2 valores na pilha:
                Erro: expressão inválida

            Remover o topo da pilha → operando2
            Remover o topo da pilha → operando1

            Se operador for "+":
                resultado = operando1 + operando2

            Senão se operador for "-":
                resultado = operando1 - operando2

            Senão se operador for "*":
                resultado = operando1 * operando2

            Senão se operador for "/":
                Se operando2 for igual a 0:
                    Erro: divisão por zero
                resultado = operando1 / operando2

            Empilhar resultado na pilha

        Senão se o item for um número:
            Converter item para número
            Empilhar o número na pilha

        Senão se o item for vazio:
            Ignorar

        Senão:
            Erro: item inválido na expressão


    Ao final da leitura dos itens:

        Se houver exatamente 1 valor na pilha:
            Retornar este valor como resultado da expressão

        Caso contrário:
            Erro: expressão mal formulada (sobraram valores na pilha)

*/