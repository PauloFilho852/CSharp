namespace TiposValorAnulaveis
{
    internal class Program
    {
        static void Main()
        {
            //O sinal ? torna um tipo valor em um tipo valor anulável. Ou seja podem ser atribuido com valor null
            int? valor = null;
            float? floatPoint;
            double? doublePoint;
            decimal? decimalPoint = null;

            //Operador coalescência nula (aqui atribuindo um tipo anulável a um não anulável). Se 'valor' for null, atribui 0
            //a valor2. (Caso haja a atibuição de um tipo anulável a um não anulável, há a emissão de erro pelo compilador).
            int valor2 = valor ?? 0;
            Console.WriteLine($"Valor de valor2: {valor2};");

            //O operador de atribuição de avaliação de nulo ??= atribuirá o valor do operando do lado direito
            //para o operando esquerdo somente se o operando esquerdo for avaliado como null.
            valor ??= 20;

            //Propriedades HasValue e Value dos tipos anuláveis
            floatPoint = 1.5f;           
            if (floatPoint.HasValue) 
                Console.WriteLine($"Valor do float anulável: {floatPoint.Value};");

           //Usando comparação com null 
            if(valor == null)
                Console.WriteLine($"Inteiro anulável têm valor nulo.");
            else
                Console.WriteLine($"Valor de 'valor': {valor.Value}");

            //Se um dos valores for nulo, o resultado é nulo.
            doublePoint = 0.5d;
            double? result = doublePoint * (double?)decimalPoint;
            if (result == null)
                Console.WriteLine($"Result é tem valor nulo.");

            //Usando a struct Nullable
            Nullable<int> valor3 = 2;

            //Imprimindo o valor sem a proprieda Value
            if (valor3 != null)
                Console.WriteLine($"Valor de valor3: {valor3}.");
            
            Console.ReadKey();
        }
    }
}
