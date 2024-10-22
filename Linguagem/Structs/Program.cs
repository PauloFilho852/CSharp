namespace Structs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Os objetos das structs são tipo valor, os dados são armazenados na pilha
            Estrutura est = new Estrutura(10);

            //e são acessados diretamente (sem referência).
            Console.WriteLine(est.Number);

            Console.ReadKey();
        }
    }

    struct Estrutura
    {
        public int Number;

        public Estrutura(int num)
        {
            this.Number = num;
        }
    }

}
