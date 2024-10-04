namespace OperadoresLogicos
{
    internal class Program
    {
        static void Main()
        {
            //Operadores lógicos trabalham com valores booleanos e retornam valores booleanos (true ou false)
            
            bool operando1 = true;
            bool operando2 = false;
            Console.WriteLine($"operando1: {operando1}");
            Console.WriteLine($"operando1: {operando2}");

            //Operando AND: retorna true se ambos forem true
            bool result = operando1 && operando2;
            Console.WriteLine($"operando1 && operando2: {result}");

            //Operando OR: retorna true se um ou outro forem true
            result = operando1 || operando2;
            Console.WriteLine($"operando1 || operando2: {result}");

            //Operando NOT: retorna o iverso do resultado
            result = !(operando1 || operando2);
            Console.WriteLine($"!(operando1 || operando2): {result}");

            //Operando como resultado de uma operação relacional
            //Operando OR: retorna true se um ou outro forem true
            Console.WriteLine($"10 > 20 || 10 < 10: {10 > 20 || 10 < 20}");

            Console.ReadKey();
        }
    }
}
