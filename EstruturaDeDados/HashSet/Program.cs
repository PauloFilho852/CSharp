namespace HashSetNamespace
{
    // Classe criada pelo usuário
    class Pessoa
    {
        public string? Nome { get; set; }
        public int Idade { get; set; }

        // Implementação dos métodos GetHashCode e Equals
        public override int GetHashCode()
        {
            return Nome?.GetHashCode() == null ? 0.GetHashCode() : Nome.GetHashCode() ^ Idade.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj is Pessoa outraPessoa)
            {
                return Nome == outraPessoa.Nome && Idade == outraPessoa.Idade;
            }

            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            // Criando um HashSet de objetos Pessoa
            HashSet<Pessoa> conjuntoPessoas = new HashSet<Pessoa>();

            // Adicionando elementos
            conjuntoPessoas.Add(new Pessoa { Nome = "Alice", Idade = 25 });
            conjuntoPessoas.Add(new Pessoa { Nome = "Bob", Idade = 30 });
            conjuntoPessoas.Add(new Pessoa { Nome = "Charlie", Idade = 35 });

            // Buscando um elemento eficientemente
            Pessoa pessoaProcurada = new Pessoa { Nome = "Alice", Idade = 25 };

            if (conjuntoPessoas.Contains(pessoaProcurada))
            {
                Console.WriteLine("A pessoa foi encontrada no conjunto.");
            }
            else
            {
                Console.WriteLine("A pessoa não foi encontrada no conjunto.");
            }
        }
    }
}