using System.Runtime.CompilerServices;

namespace CamposPropriedades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CampoEstatico campoEstatico = new(10);

            Console.WriteLine($"Campo de instância: {campoEstatico.campoInstancia}.");

            //Campos estáticos pertencem à classe, não à instância
            Console.WriteLine($"Campo Estático: {CampoEstatico.Value}.");

            Console.WriteLine($"Campo Estático: {CampoEstatico.Value}.");

            Console.ReadKey();
        }
    }

    public class CampoEstatico
    {
        //Um construtot estático não usa modificadores de acesso nem tem parâmetros.
        //Uma classe ou struct só pode ter um único construtor estático.
        //Um construtor estático não pode ser chamado diretamente.
        //Ele é chamado automaticaticamente, antes que a primeira instância seja criada,
        //ou, ao se usar um campo estático. Uma única vez.
        //O usuário não tem controle sobre quando  o construtor estático é executado no programa.
        //Se você naõ fornece um construtor estático, os campos estáticos serão inicializados com valor padrão.
        //Se o construtor estático gerar uma exceção, o runtime não o chamará o outra vez e o membro
        //estático permanecerá não inicializado durante o tempo de vida do aplicativo.
        static CampoEstatico()
        {
            Console.WriteLine("Chamada do construtor estático!");
            Value = 1;
        }

        //Campos estátivos pertecem à classe, não à instância.
        public static int Value;

        public int campoInstancia;

        public CampoEstatico(int campoInstancia)
        {
            this.campoInstancia = campoInstancia;
        }

        class Propriedades
        {
            //As propriedades permitem que uma classe exponha uma maneira pública de obter e 
            //definir valores, enquanta oculta o código de implementação, por meio de métodos
            //especiais chamadados acessadores. É a associação de um campo privado e dois métodos
            //acessadores: o get e e o set.
            private int meuCampo;
            public int MinhaPropiedade
            {
                get { return meuCampo; }
                set { meuCampo = value; }
            }

            //Propriedade automática. Criação automática de campo e metódos acessadores
            //para casos em que não existe a necessidade implementação de código de acesso)
            public int MinhaPropriedadeAutomatica {get; set;}

            //Propriedade somente leitura
            public string? Nome { get; }

            //Propriedade somente escrita
            private int somenteEscrita;
            public int SomenteEscrita { set { somenteEscrita = value; } }            
        }        
    }
}
