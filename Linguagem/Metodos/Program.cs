using System.Formats.Asn1;

namespace Metodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10;

            Metodos metodos = new Metodos();

            metodos.ImprimeAssinaturaDeUmMetodo();

            //Palavara ref - passagem de argumentos como referência. As variáveis
            //usadas como argumentos podem ser modificadas dentro do método. Assim podem
            //refletir o processamento do método.
            Console.WriteLine($"a: {a}");
            metodos.PassagemPorReferencia(ref a);
            Console.WriteLine($"a: {a}");


            //Palavara out - passagem de agumentos por refêrencia. Não há necessidade de inicialização
            //da variável usada como argumento, assim os argumentos podem ser declarados na chamada 
            //da função. A palavara out obriga a inicialização da variável no corpo de método de chamada. 
            metodos.CalculaAreaPerimetro(10, out double area, out double perimetro);
            Console.WriteLine($"Area {area}, Perimetro {perimetro}");

            //Argumentos nomeados permitem ignorar a ordem em que estão os parâmetros.
            metodos.Enviar(titulo: "Reunião", email: "paulofilho@gmail.com", assunto: "Oçamento anual.");

            //Parâmetros opcionais permitem a omissão de argumentos.
            metodos.Enviar2(email: "paulofilho@gmail.com");

            Console.WriteLine();

            //Métodos estáticos pertecem à classe não à instância.
            Metodos.MetodoEstatico();

            Console.ReadKey();
        }
    }    

    public class Metodos
    {
        public void ImprimeAssinaturaDeUmMetodo()
        {
            string assinatura = "Nome do método, quantidade, tipo e ordem dos parâmentros são a assinatura de um método.";
            string naoAssinatura = "O tipo de retorno não faz parte da assinatura do método.";
            Console.WriteLine(assinatura);
            Console.WriteLine(naoAssinatura);


            return;
        }

        public void PassagemPorReferencia(ref int x)
        {
            x += 10;

            return;
        }

        public void CalculaAreaPerimetro(double raio, out double area, out double perimetro)
        {
            area = Math.PI * Math.Pow(raio, 2);
            perimetro = 2 * Math.PI * raio;
        }

        public void Enviar(string email, string titulo, string assunto)
        {
            Console.WriteLine($"\nPara: {email} - {titulo}.\nAssunto: {assunto}.");
        }


        //Parâmentros opcionais devem ficar depois dos parâmetros obrigatórios.
        public void Enviar2(string email, string titulo = "Reunião Hoje", string assunto = "Ugente")
        {
            Console.WriteLine($"\nPara: {email} - {titulo}.\nAssunto: {assunto}.");
        }

        //Métodos Estáticos.
        public static void MetodoEstatico()
        {
            int local = 10;
            Console.WriteLine($"Métodos Estáticos pertecem à classe.\n" +
                $"Não há necessidade de instaciãção de objeto para acessá-los.\n" +
                $"Não podem usar campos e propiedades das instâncias. Variável local: {local}.");
        }
    }
}
