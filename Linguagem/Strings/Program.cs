namespace Strings
{
    internal class Program
    {
        static void Main()
        {
            //Concatenação
            string ultimoNome = "Filho";
            string stringConcatenada = "Paulo " + "Carvalho " + "de Medeiros " + ultimoNome;
            Console.WriteLine(stringConcatenada);

            //Interpolção
            int idade = 9;
            string nome = "Pedro";
            string interpolacao = $"{nome} tem {idade} anos.";
            Console.WriteLine(interpolacao);

            //Place holders (para saída)
            Console.WriteLine("{0} tem {1} anos.", nome, idade);

            //Sequencias de escape
            //Utilza-se a contrabarra '\' para se utilizar sequências de escpape.
            //'\n' -> Sequência de escape que representa uma nova linha
            string title = "Sequências de escape:\n";
            //'\\' Duas contrabarras para indicar um contrabarra.
            string path = "D:\\Diretorio\\File.txt";
            Console.WriteLine(title);
            Console.WriteLine(path);

            //Usando o @ para implementar caminhos (para não ter que usar duas contrabarras)
            string path2 = @"D:\Diretorio\File.txt";
            Console.WriteLine(path2);

            //Aviso
            Console.WriteLine("\nAviso: Na image SequenciaEscape.png existem exemplos de sequências de escape.");

            Console.ReadKey();

            return;
        }
    }
}
