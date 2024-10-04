using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models
{
    
    //[Table("Produtos")]//-->Opcional, pois:
    //na classe de contexto, as propriedades públicas já dão nome às tabelas
    public class Categoria
    {
        public Categoria() 
        {
            Produtos  = new Collection<Produto>();
        }

        //[Key] //Opcional, pois:
        //O Entity Framework Core reconhece 'Id' ou 'ClassNameId'.
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(300)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set;}

        //Relacionamento 1 para muitos de Categorias para Produtos
        public ICollection<Produto>? Produtos { get; set; }
    }
}

/*Data Annotations:
 * -Validação de entrada de dados
 * -Formatação e exibição de dados
 * -Geração de código
 * -Especificar o relacionamento entre as entidades
 * -Sobrescrever as convenções do EF Core.
 *
 *Classes anêmicas
 * a definição mais precisa é que uma classe anêmica é aquela que carece de comportamento significativo
 * (que afete o modelo), servindo apenas como um repositório de dados. 
 */
