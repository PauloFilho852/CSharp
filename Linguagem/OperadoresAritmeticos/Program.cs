namespace OperadoresAritmeticos
{
    internal class Program
    {
        static void Main()
        {
            int x = 10;
            int y = 4;

            Console.WriteLine($"Valor do tipo inteiro x: {x}. Valor do tipo intero y: {y}.");
            Console.WriteLine($"Operador de soma (x + y): {x + y}.");
            Console.WriteLine($"Operador de subtração (x - y): {x - y}.");
            Console.WriteLine($"Operador de multiplicação (x * y): {x * y}.");
            
            //Divisão entre inteiros retorna inteiro, a não ser que se faça um castin implícito (float)x /y
            Console.WriteLine($"Operador de divisão  (x / y): {x / y}.");

            Console.WriteLine($"Operador de módulo - resto da divisão (x % y): {x % y}.");

            Console.ReadKey();

            return;
        }
    }
}
