namespace OperadoresRelacionais
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Operadores relacionais retornam um valor booleano (true ou false)

            int x = 10;
            int y = 20;

            Console.WriteLine($"x: {x}. y: {y}.");

            //Igualdade: se x for igual a y, z atribuido com true, se não false.
            bool z = x == y;
            Console.WriteLine($"x == z: {z}");

            //Maior ou igual: se x for maior ou igual a y, z atribuido com true, se não false.
            z = x >= y;
            Console.WriteLine($"x >= z: {z}");

            //Menor ou igual: se x for menor ou igual a y, z atribuido com true, se não false.
            z = x <= y;
            Console.WriteLine($"x <= z: {z}");

            //Menor que: se x for menor que y, z atribuido com true, se não false.
            z = x < y;
            Console.WriteLine($"x < z: {z}");

            //Maior que: se x for maior que y, z atribuido com true, se não false.
            z = x > y;
            Console.WriteLine($"x > z: {z}");

            //Diferente de: se x for diferente y, z atribuido com true, se não false.
            z = x != y;
            Console.WriteLine($"x > z: {z}");

            string paulo1 = "Paulo";
            string paulo2 = "paulo";

            //Uso de operadores relacionais com strings (tipo objeto).
            bool c = paulo1 == paulo2;
            Console.WriteLine($"paulo1 == paulo2: {c}.");

            //Método Equals tem o mesmo efeito do operador de igualdade ==
            Console.WriteLine($"paulo1.Equals(paulo1): {paulo1.Equals(paulo1)}.");

            Console.ReadKey();
        }
    }
}
