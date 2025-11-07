public static class ArraySelector
{
    public static void Run()
    {   //arrays de teste
        var list1 = new[] { 1, 2, 3, 4, 5 };
        var list2 = new[] { 2, 4, 6, 8, 10 };
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };
        var intResult = ListSelector(list1, list2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5} resultado esperado
    }
    //summary:
    //The two arrays are combined together into a new array according to the selector array. 

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        int[] result = new int[select.Length];//inicializa um novo array de inteiros (result) com o mesmo tamanho do array select, ou seja 10 posições

        //utilizar contadores para saber a posição em cada lista
        int array1Index = 0;//rastreia a próxima posição em list1 | na função Run: list1 = {1, 2, 3, 4, 5}, logo a posição 0 refere-se ao primeiro valor que é 1
        int array2Index = 0;//rastreia a próxima posição em list2 | na função Run: list2 = {2, 4, 6, 8, 10} logo a posição 0 refere-se ao primeiro valor que é 2


        //iterar sobre o array select
        for (int i = 0; i < select.Length; i++) //percorre o array select do inicio ao fim ao incrementar o valor de i (0+1 <menor que 10 onde 10 é o tamanho do array select), 
        // próximo laço 1+1 = 2 < 10...até 9+1 saltando fora da condição pois 9+1=10 ... não é menor que 10...já atende a condição. Essas iterações vão preencher o array result
        {
            //o indice i é a posição onde vamos guardar o resultado. Se a iteração encontrar um valor apos as condições dos ifs utilizados para alternar entre as duas lists, esse 
            //valor será colocado no index [i] apropriado 
            //o valor de select[i] mostra onde obter o elemento. select[i index do elemento]

            //if para alternar entre as list1 e list2. 
            if (select[i] == 1)
            { //se o select for 1 então pegamos o elemento da list1 

                //if para verificar se o índice está dentro do limite
                //if (array1Index < list1.Length)
                //{

                result[i] = list1[array1Index];//aqui pegamos o valor de list1 na posição atual array1Index e guardamos no posição index do array result:

                /* o esquema é o seguinte. Considere os itens de Run:
                
                list1 = new[] { 1,  2,  3,  4,  5 };
                        index  [0],[1],[2],[3],[4]

                list2 = new[] { 2,  4,  6,  8, 10 };
                        index  [0],[1],[2],[3],[4]
                
                1) INICIO do LOOP

                select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };)

                o laço for percorre todos os indexs do array select, se ao percorrer encontrar o valor 1 então é direcionado para list1 econtrando o valor de array1Index nesta posição de list1, 
                como determinamos que o array1Index = 0, então começamos a contar apartir do primeiro index que é a posição 0 cujo valor em list1 é igual a 1
                o array result fica assim:

                      result = {1}

                list1 = new[] { 1,  2,  3,  4,  5 };
                        index  [0],[1],[2],[3],[4]

                2) o laço for encontra o próximo index. Após encontrar o primeiro resultado o index1 que começou com valor 0 é incrementado em 1, permitindo que seja verificado o próximo item
                do array select. Logo 0+1 = 1 o próximo index de select encontra nesta posição o valor 1 que é direcionado novamente para list1 econtrando o valor de array1Index nesta posição de list1
                cujo valor é 2.
                o array result fica assim:

                    result =  { 1,  2}
                list1 = new[] { 1,  2,  3,  4,  5 };
                        index  [0],[1],[2],[3],[4]

                3) O laço percorre o array select depois de incrementado o arrayIndex1 (1 +1 = 2 ) indicando a 2ª posição no array select cujo valor é 3. 

                o array result fica assim:

                      result = {1,  2,  3}

                list1 = new[] { 1,  2,  3,  4,  5 };
                        index  [0],[1],[2],[3],[4]

                4) O laço percorre o array select depois de incrementado o arrayIndex1 (2 + 1 = 3 ) indicando a 3ª posição index no array select cujo valor é 2, logo a iteração busca os itens na list2 encontrando o valor array2Index = 0
                significando a primeira posição index nesta list2, cujo valor é igual a 2. 

                o array result fica assim:

                      result = {1,  2,  3,  2}

                            list2 = new[] { 2,  4,  6,  8, 10 };
                                  index    [0],[1],[2],[3],[4]
                
                5) O laço percorre o array select depois de incrementado o arrayIndex2 (0 + 1 = 1 ) buscamos a posição index 1 no array select cujo valor é 2 logo permanecemos na list2. a posição 1 em list2 é igual ao valor 4:

                o array result fica assim:

                      result = {1,  2,  3,  2,  4}

                            list2 = new[] { 2,  4,  6,  8, 10 };
                                  index    [0],[1],[2],[3],[4]

            6) O laço percorre o array select depois de incrementado o arrayIndex2 (1 + 1 = 2 ), como estamos na posição 6 do array select logo encontramos o valor 1 que nos direciona para o array list1 no próximo valor
            desta lista que estava em 3 resultado de arrayIndex1++ gerando 3+1 = 4 (posição 4 no array list1 é igual ao valor 4)

                o array result fica assim:

                result = {1,  2,  3, 4, 4}

                list1 = new[] { 1,  2,  3,  4,  5 };
                        index  [0],[1],[2],[3],[4]
                

            7) o laço percorre o array select depois de incrementar o arrayIndex1 (3 + 1 = 4), estamos agora na posição 7 do array select logo encorntramos o valor 2 que nos direciona para a list2, valor que usamos a ultima 
            iteração foi 2  oriunda de arrayIndex2++ (1+1 = 2) e agora 2+1 = 3 logo a posição 3 no array list2 é igual ao valor 6

                o array result fica assim:

                result = {1,  2,  3, 4, 4, 6}

                list2 = new[] { 2,  4,  6,  8, 10 };
                      index    [0],[1],[2],[3],[4]

            
            8) o laço percorre o array select depois de incrementar o arrayIndex2 (3 + 1 = 4), estamos agora na posição 8 do array select logo encorntramos o valor 2 que nos direciona para a list2, valor que usamos a ultima 
            iteração foi 3  oriunda de arrayIndex2++ (2+1 = 3) e agora 3+1 = 4 logo a posição 4 no array list2 é igual ao valor 8. Segue então os próximos itens do array select seguindo a mesma lógica...

                o array result fica assim:

                result = {1,  2,  3, 4, 4, 6, 8, }

                list2 = new[] { 2,  4,  6,  8, 10 };
                      index    [0],[1],[2],[3],[4]

                Trace com maiores detalhes do loop:
                
            select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1 };.

            list1 = new[] { 1, 2, 3, 4, 5 }; (array1Index = 0 a 4)
            list2 = new[] { 2, 4, 6, 8, 10 }; (array2Index = 0 a 4)

            1) i=0, select[0]=1. result[0]=list1[0]=1. array1Index = 1.
               result = {1}
            
            2) i=1, select[1]=1. result[1]=list1[1]=2. array1Index = 2.
               result = {1, 2}
            
            3) i=2, select[2]=1. result[2]=list1[2]=3. array1Index = 3.
               result = {1, 2, 3}
            
            4) i=3, select[3]=2. result[3]=list2[0]=2. array2Index = 1.
               result = {1, 2, 3, 2}
            
            5) i=4, select[4]=2. result[4]=list2[1]=4. array2Index = 2.
               result = {1, 2, 3, 2, 4}

            6) i=5, select[5]=1. result[5]=list1[3]=4. array1Index = 4.
               result = {1, 2, 3, 2, 4, 4}
            
            7) i=6, select[6]=2. result[6]=list2[2]=6. array2Index = 3.
               result = {1, 2, 3, 2, 4, 4, 6}

            8) i=7, select[7]=2. result[7]=list2[3]=8. array2Index = 4.
               result = {1, 2, 3, 2, 4, 4, 6, 8}

            9) i=8, select[8]=2. result[8]=list2[4]=10. array2Index = 5. (array2Index atingiu o limite)
               result = {1, 2, 3, 2, 4, 4, 6, 8, 10}

            10) i=9, select[9]=1. result[9]=list1[4]=5. array1Index = 5. (array1Index atingiu o limite)
                result = {1, 2, 3, 2, 4, 4, 6, 8, 10, 5}
                
            FIM DO LOOP: i torna-se 10, e 10 < 10 é FALSO. O loop termina.


        **/


                array1Index++; //avança mais itens da list1
                //}

            }
            else if (select[i] == 2)
            {

                //if (array2Index < list2.Length)
                // {

                result[i] = list2[array2Index];
                array2Index++;// avança mais um item de list2
                //}
            }
        }
        return result;
    }
}