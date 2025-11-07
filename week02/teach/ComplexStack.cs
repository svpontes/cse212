public static class ComplexStack
{
    public static bool DoSomethingComplicated(string line)
    {
        var stack = new Stack<char>();
        foreach (var item in line)
        {
            if (item is '(' or '[' or '{')
            {
                stack.Push(item);
            }
<<<<<<< HEAD
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(') 
=======
            else if (item is ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
>>>>>>> 74c5c70814141cc7d802dd1334855851fe8f0187
                    return false;
            }
            else if (item is ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        } 

        return stack.Count == 0;
    }
}