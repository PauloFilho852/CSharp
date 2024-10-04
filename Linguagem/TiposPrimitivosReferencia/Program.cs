namespace TiposPrimitivosReferencia
{
    internal class Program
    {
        static void Main()
        {
            //Tipo string: array de caracteres unicode. Strings são imutáveis
            string nome = "Paulo Carvalho";
            Console.WriteLine(nome);
            //Uma nova string é criada. A antiga continua na memória e será removida pelo Garbage Collector.
            nome = "Paulo Filho";
            Console.WriteLine(nome);

            //object é um tipo genérico que recebe todos os tipos de dados. Pode ser útil como um parâmetro genêrico.
            object str = "string";
            object boolean = true;
            object inteiro = 1;
            object flutuante = 1.5m;
            Console.WriteLine($"{str}. {boolean}. {inteiro}. {flutuante}.");

            //dynamic tem comportamento semelhante ao object. É útil em certas situações como em uso de Reflections ou
            //ou em uso de linguagens dinâmicas através do DLR - Dynamic Language Runtime 
            dynamic dstr = "string";
            dynamic dboolean = true;
            dynamic dinteiro = 1;
            dynamic dflutuante = 1.5m;
            Console.WriteLine($"{dstr}. {dboolean}. {dinteiro}. {dflutuante}.");

            //Operado ? indica explicitamente que a referência é anulável
            //caso não seja utilizado, é emitido um alerta do computador.
            object? objeto = null;
            
            objeto = "objeto é uma string";

            if(objeto is string)
            {
                string _string = (string)objeto;
                Console.WriteLine(_string);
                Console.WriteLine(_string.ToUpper());
            }
            else
            {
                Console.WriteLine("objeto é nulo");
            }



            Console.ReadKey();
        }
    }
}
