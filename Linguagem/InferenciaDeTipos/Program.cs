namespace InferenciaDeTipos
{
    internal class Program
    {
        static void Main()
        {
            //C# é uma linguagem estática e fortemente tipada. Isso quer dizer que os
            //tipos são definidos em tempo de compilação e não é permitidao, posteriormente, atribuição 
            //de um tipo diferente de dados (exceto em caso castings implícitos e explícitos),
            //assim como não é permitido operações entre tipos numéricos e não numéricos.

            //Podemos usar inferências de tipos com a palavra 'var' no escopo de métodos,
            //chamado de declaração implícita. O compilador utiliza o valor para inferir
            //o tipo de dados.

            var a = 46;     //Inferido o tipo inteiro
            var b = 2500.50m;   //Inferido o itpo float
            var s = "Paulo.";

            //var c; -> Não permitido. Variáveis tipadas implicitamente devem ser inicializadas
            //var c = null -> Não permitido. Não se pode atribuir null a variáveis tipadas implicitamente.
            //var c, b, d = 0;

            Console.WriteLine($"{s} tem {a} anos e ganha {b:c}");

            //Uma grande utilidade da palavra var é a definição de tipos anônimos.
            var anomimousType = new { Nome = "Paulo", Idade = 49 };
            Console.WriteLine($"{anomimousType.Nome} tem {anomimousType.Idade} anos.");

            //Usa-se também em laços foreach e instuções using
        }
    }
}
