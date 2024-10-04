using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
                "VALUES ('Coca-Cola Diet', 'Refrigerante de Cola 350ml', 5.45, 'cocacola.jpg', 50, GETDATE(), 2)");
            
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
               "VALUES ('Lanche de Atum', 'Lanche de Atum com Maionese', 8.50, 'atum.jpg', 10, GETDATE(), 3)");

            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, DataCadastro, CategoriaId)" +
               "VALUES ('Pudim 100g', 'Pudim de Leite Condensado 100g', 6.75, 'pudim.jpg', 20, GETDATE(), 4)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
