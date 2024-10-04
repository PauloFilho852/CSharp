namespace ConversaoDeTipos
{
    internal class Program
    {
        static void Main()
        {
            //Método ToString() -> convert um tipo em string
            int inteiro = 22343234;
            string stringInteiro = inteiro.ToString();
            Console.WriteLine(stringInteiro);

            //A conversão implícita ocorre quando um tipo cabe dentro do intervalo de representação
            //do outro, no entanto, ainda há a possibilidade de perda de precisão quando conversão
            //entre inteiros e pontos flutuantes.

            //Conversão implícita (perda precisão)
            long inteiroLong = 923622751234567890;
            Console.WriteLine($"long com valor grande: {inteiroLong}.");
            float floatNumber = inteiroLong;
            Console.WriteLine($"Tipo float atribuído com long implicitamente: {floatNumber}.");
            Console.WriteLine($"Tipo float atribuído com long realizando aproximação para o long: " + floatNumber.ToString("f0") + ".");

            //Conversão implícita entre inteiros matém a integridade do valor.
            short shortInt = 254;
            int inteiro2 = shortInt;
            Console.WriteLine($"Tipo short atribuido para int (254): {inteiro2}");


            //A conversão explícita ocorre quando um tipo não cabe no intervalo de representação
            //do outro. Usa-se o operador de casting. Também há a possibilidade de perda de precisão
            
            //Conversaõ explícita (perda de precisão)
            float _float = 1.23f;
            int inteiro3 = (int)_float;
            Console.WriteLine($"int atribuido com float fazendo casting explícito (1,23): {inteiro3}.");


            //Divisão entre tipos inteiros retorna inteiro. Necessário fazer um casting.
            int inteiro4 = 5;
            int inteiro5 = 2;
            double doubleNum1 = inteiro4 / inteiro5;
            Console.WriteLine($"double atribuido com divisão de int's (5/2) {doubleNum1}.");
            
            
            //Conversão explícita para float e implícita para double.
            double doubleNum2 = (float)inteiro4 / inteiro5;
            Console.WriteLine($"double atribuido com divisão de int's (5/2) {doubleNum2}.");


            //Classe Convert
            int inteiro6 = Convert.ToInt32(_float);
            Console.WriteLine($"Convesão de float para long com a classe Convert (1,23): {inteiro6}.");

            
            //Casting explícito com perda de dados
            short shortNum = (short)inteiroLong;
            Console.WriteLine($"Mudança de long para short com perda de dados: {shortNum}");


            //Coversão de com a classe Convert com geração de exceção: "OverFlowException"
            try
            {
                short shortNum2 = Convert.ToInt16(inteiroLong);
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Inteiro long não atribuído a tipo short: {inteiroLong}");
            }

            Console.ReadKey();    


            return;
        }
    }
}
