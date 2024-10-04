namespace OperadoresDeAtribuicao
{
    internal class Program
    {
        static void Main()
        {
            int x;

            x = 10; //Operador =. x recebe o valor 10.
            x += 5; //Operador +=. x recebe o valor de x + 5 ( x = x + 5).
            x -= 5; //Operador -=. x recebe o valor de x - 5 ( x = x - 5).
            x *= 5; //Operador *=. x recebe o valor de x * 5 ( x = x * 5).
            x /= 5; //Operador +=. x recebe o valor de x / 5 ( x = x / 5).
            x %= 5; //Operador %=. x recebe o valor de x % 5 ( x = x % 5).

            Console.WriteLine($"Valor de x: {x}");

            //Incremento. Operador ++. x recebe o valor de x + 1 (x = x + 1)
            x++; 
            Console.WriteLine($"Valor de x: {x}");

            //Decremento. Operador --. x recebe o valor de x - 1 (x = x - 1)
            x--;
            Console.WriteLine($"Valor de x: {x}");

            //x é somado, e somente incrementado depois da instrução (pós-incremento).
            int resultado = x++ + 10;
            Console.WriteLine($"Valor do resultado: {resultado}");

            //x é incrementado e somado na mesma instrução (pré-incremento).
            resultado = ++x + 10;
            Console.WriteLine($"Valor do resultado: {resultado}");


            //O operador de atribuição de avaliação de nulo ??= atribuirá o valor do operando do lado direito
            //para o operando esquerdo somente se o operando esquerdo for avaliado como null.
            int? y = null;
            y ??= 10;
            Console.WriteLine($"Valor de y: {y}");
             
            string paulo = "Paulo ";

            //Operador += com strings. paulo recebe o valor de paulo + "Filho" (paulo = paulo + "Filho")
            paulo += "Filho"; 
            Console.WriteLine(paulo);

            Console.ReadKey();
        }
    }
}
