namespace Enum
{
    internal class Program
    {
        static void Main()
        {
            DiasDaSemana dia = DiasDaSemana.Sexta;
            
            Console.WriteLine($"Hoje é {dia}. Número: {(byte)dia}");

            Console.ReadKey();
        }
    }

    //Enumerações podem ser definidas dentro de namespaces, classes ou structs
    //Podem ser atribuidos valores. Os valores seguintes serão incrementais.
    //Por padrão o tipo é int, mas pode ser atribuido qualquer tipo numérico
    enum DiasDaSemana : byte
    {
        Segunda = 5,
        Terca,
        Quarta,
        Quinta, 
        Sexta,
        Sabado,
        Domingo
    }
}
