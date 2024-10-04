﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using APICatalogo.Validations;

namespace APICatalogo.Models
{
    //[Table("Produtos')]-->Opcional, pois:
    //na classe de contexto, as propriedades públicas já dão nome às tabelas
    public class Produto
    {
        //[Key] -> Opcional, pois:
        //O Entity Framework Core reconhece 'Id' ou 'ClassNameId'.
        public int ProdutoId { get; set; }

        [Required] //Data Annotations: permitem a validação de dados de entrada do modelo.
        [StringLength(300)] //Propriedade obrigatória, tamanho máximo de 300 caracteres
        [PrimeiraMaiuscula] //Validação personalizada
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300, ErrorMessage ="O nome deve ter entre 20 e 300 caracteres.", MinimumLength =20)]
        public string? ImagemUrl { get; set; }

        //[BindNever] Atributo de model bind que informa que a propriedade não deve receber
        //valor por meio de uma action
        public float Estoque { get; set; }

        public DateTime DataCadastro { get; set; }

        //Estabelecendo o relacionamento entre Produtos e Categorias
        public int CategoriaId {  get; set; }

        //Será ignorado a serialização quando for null
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Categoria? Categoria { get; set; }
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