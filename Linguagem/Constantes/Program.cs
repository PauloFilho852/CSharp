namespace Constantes
{
    internal class Program
    {
        static void Main()
        {
            //Constantes são valores imutáveis que são conhecidos em tempo de compilação e
            //não mudam durante a vida útil do programa.
            //As constantes são declaradas usando o modificador const e devem ser inicializadas na sua
            //declaração. É uma boa prática usar o indentificador usando maiúsculas.
            //Uma constante só pode ser atribuída por outra constante

            const int DIAS_POR_ANO = 365;
            const int MESES_POR_ANO = 12;
            const float DIAS_POR_MÊS = (float)DIAS_POR_ANO / MESES_POR_ANO;

            Console.WriteLine($"Dias por ano: {DIAS_POR_ANO}.");

            Console.WriteLine($"Meses por ano: {MESES_POR_ANO}.");

            Console.WriteLine($"Dias por mês: {DIAS_POR_MÊS}.");

            Console.ReadKey();
        }
    }
}
