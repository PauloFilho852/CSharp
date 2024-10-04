using static System.Console;
namespace TiposValorPrimitivos
{
    internal class Program
    {
        static void Main()
        {
            //Tipos Valor (armazenados na Stack por meio de structs)

            TiposInteiros();
            TiposPontoFlutuante();
            TipoBooleano();
            TipoCaracater();
        }

        static void TiposInteiros()
        {
            WriteLine("Tipos inteiros.");
            WriteLine('\n');

            sbyte minValue1 = sbyte.MinValue;
            sbyte maxValue1 = sbyte.MaxValue;
            PrintInt("sbyte", minValue1, maxValue1, sizeof(sbyte), true);
            WriteLine('\n');

            byte minValue2 = byte.MinValue;
            byte maxValue2 = byte.MaxValue;
            PrintInt("byte", minValue2, maxValue2, sizeof(byte), false);
            WriteLine('\n');

            short minValue3 = short.MinValue;
            short maxValue3 = short.MaxValue;
            PrintInt("short", minValue3, maxValue3, sizeof(short), true);
            WriteLine('\n');

            ushort minValue4 = ushort.MinValue;
            ushort maxValue4 = ushort.MaxValue;
            PrintInt("ushort", minValue4, maxValue4, sizeof(ushort), false);
            WriteLine('\n');

            int minValue5 = int.MinValue;
            int maxValue5 = int.MaxValue;
            PrintInt("int", minValue5, maxValue5, sizeof(int), true);
            WriteLine('\n');

            uint minValue6 = uint.MinValue;
            uint maxValue6 = uint.MaxValue;
            PrintInt("uint", minValue6, maxValue6, sizeof(uint), false);
            WriteLine('\n');

            long minValue7 = long.MinValue;
            long maxValue7 = long.MaxValue;
            PrintInt("long", minValue7, maxValue7, sizeof(long), true);
            WriteLine('\n');

            ulong minValue8 = ulong.MinValue;
            ulong maxValue8 = ulong.MaxValue;
            PrintInt("ulong", minValue8, maxValue8, sizeof(long), true);
            WriteLine('\n');

            //nint: intervalo depende da plataforma. Sinalizado de 32 ou 64 bits. System.IntPtr
            //nuint: intervalo depende da plataforma. Não sinalizado de 32 ou 64 bits. System.UIntPtr

            ReadKey();

            return;
        }

        static void TiposPontoFlutuante()
        {
            WriteLine("Tipos de ponto flutuante.");
            WriteLine('\n');

            //sufixos para declaração de variáveis
            //float value = 1.5f;
            //double value = 1.5d;
            //decimal value = 1.5m;

            //float: média de 6 a 9 dígitos de precisão
            //Incapacidade de representa certos números em base decimal, exemplo: o número 0.1f é uma aproximação binária.
            //Isso por levar a erros de arredondamento. A mesma observação serve para o double.
            float from1 = float.Epsilon;
            float to1 = float.MaxValue;
            PrintFloat("float", from1, to1, sizeof(float));
            WriteLine("\n");

            //float: média de 15 a 17 dígitos de precisão            
            double from2 = double.Epsilon;
            double to2 = double.MaxValue;
            PrintFloat("double", from2, to2, sizeof(double));
            WriteLine("\n");

            //decimal: 28 a 29 dígitos de precisão.
            //O tipo decimal em C# é projetado para representar números decimais com exatidão dentro
            //Ele é ideal para aplicações que exigem alta precisão decimal,como cálculos financeiros e contábeis,
            //onde os erros de arredondamento devem ser minimizados. Ao contrário dos tipos float e double, o decimal
            //utiliza uma base de 10, permitindo uma representação exata de números decimais.
            decimal from3 = (decimal)(1 / Math.Pow(10, 28));
            decimal to3 = decimal.MaxValue;
            PrintFloat("decimal", from3, to3, sizeof(decimal));
            WriteLine("\n");

            ReadKey();

            return;
        }

        static void TipoBooleano()
        {
            WriteLine("Tipo booleano.");
            WriteLine('\n');

            //Armazenam valores verdadeiro e falso

            bool _false = false;
            bool _true = true;

            WriteLine($"bool: {_false} ou {_true}. Tamanho {sizeof(bool)} byte. Tipo .NET: {_true.GetType()}");
            WriteLine("\n");

            ReadLine();

            return;
        }

        static void TipoCaracater()
        {
            WriteLine("Tipos de caracter.");
            WriteLine('\n');

            char caracter = 'A';
            char caracter2 = '\u0041'; //Código Unicode
            WriteLine($"Caracter {caracter}. Outro caracter: {caracter2}.");
            WriteLine("\n");

            ReadKey();

            return;
        }

        static void PrintInt<T>(string type, T minValue, T maxValue, byte size, bool signed)
        {
            string sinalizado = signed ? "Sinalizado" : "Não sinalizado";
            WriteLine($"{type}: Menor valor: {minValue}. Maior valor: {maxValue}. {sinalizado} de {size} byte(s). Tipo .NET: {minValue?.GetType()}");

            return;
        }

        static void PrintFloat<T>(string type, T from, T to, byte size)
        {
            WriteLine($"{type}: de +/- {from} a +/- {to}. Tamaho: {size} byte(s). Tipo .NET: {from?.GetType()}");

            return;
        }
    }
}
