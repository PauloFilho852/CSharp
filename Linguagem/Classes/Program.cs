using System.Runtime.CompilerServices;

namespace Classes
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Palavra this:");

            Aluno aluno = new("Paulo", 23);

            aluno.Print();

            Console.ReadKey();
        }
    }

    public class Aluno
    {
        public string nome;
        public int idade;
        public Aluno(string nome)
        {
            this.nome = nome;
            Console.WriteLine("Chamada ao construtor a.");
        }

        public Aluno(string nome, int idade):this(nome)
        {
            this.idade = idade;
            Console.WriteLine("Chamada ao construtor b.");
        }

        private void Exibir(Aluno aluno)
        {
            Console.WriteLine($"Nome: {aluno.nome}. Idadade: {aluno.idade}.");
        }

        public void Print()
        {
            Exibir(this);
        }
    }
}
