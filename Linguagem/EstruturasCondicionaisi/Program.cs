using System.Linq.Expressions;

namespace EstruturasCondicionaisi
{
    internal class Program
    {
        static void Main()
        {
            int x = 10;
            int y = 15;

            if (x < y)
            {
                Console.WriteLine("x é maior que y.");
            }

            if (y < x)
            {
                Console.WriteLine("y é maior que x.");
            }
            else
            {
                Console.WriteLine("x é maior que y.");
            }

            bool condicao1 = false;
            bool condicao2 = true;
            bool condicao3 = false;

            if (condicao1)
            {
                Console.WriteLine("A condição 1 é verdadeira");
            }
            else if (condicao2)
            {
                Console.WriteLine("A condição 2 é verdadeira e condição 1 é falsa!");
            }
            else if (condicao3)
            {
                Console.WriteLine("A condição 3 verdadeira e as condções 1 e 2 são falsas");
            }
            else
            {
                Console.WriteLine("Todas condições são falsas.");
            }

            string paulo = "Paulo";

            switch (paulo)
            {
                case "Paulinho":
                case "Paulo":
                    Console.WriteLine("Meu nome é Paulo ou Paulinho.");
                    break;
                default:
                    Console.WriteLine("Meu nome não é Paulo nem é Pauinho.");
                    break;

            }


            int g = -1;
        label:

            g++;

            Console.WriteLine($"g: {g}");


            if (g < 10)
                goto label;


            int i = 0;

            while (true)
            {
                Console.WriteLine($"i: {i}");

                if (i == 10)
                    break;

                i++;
            }

            i = 0;

            do
            {
                Console.WriteLine($"i: {i}");

                if (i == 10)
                    break;
                i++;


            } while (true);

            i = 0;

            while (true)
            {
                if (i == 5)
                {
                    i++;
                    continue;
                }


                if (i == 11)
                    break;

                Console.WriteLine($"i: {i}");

                i++;
            }

            for (int a = 0; a < 10; a++)
            {
                Console.WriteLine($"a: {i}");
            }

            int[] ints = [10, 20, 30, 40, 50, 60, 70, 80];

            foreach (var c in ints)
            {
                Console.WriteLine($"c: {c}");
            }

            Console.ReadKey();
        }
    }
}
