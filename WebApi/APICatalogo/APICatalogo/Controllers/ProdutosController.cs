using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APICatalogo.Context;
using APICatalogo.Models;
using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //Reponsável pela validação automática de entrada dos modelos, definida por atributos data annotations.
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProdutosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetAsync()
        {
            //AsNoTrackin(): entidades não são rastreadas para posterior salvamento com SaveChanges();
            //Nunca retorne todos os registros

            List<Produto>? produtos = null;
            try
            {
              produtos = await _appDbContext.Produtos.AsNoTracking().Take(10).ToListAsync();                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu erro ao tratar sua solicitação.");
            }

            if (produtos == null)
                return NotFound("Produtos não encontrados.");

            return produtos;
        }

        //[HttpGet("/categorias")] -> ignora o parâmetro definido no atributo Route, que define as rotas
        //[HttpGet("teste")] -> adiciona um nova rota que pode ser atendida pelo endpoint
        [HttpGet ("categorias")] //adiciona o valor /categorias à rota 
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosComCategorias()
        {
            List<Produto>? produtos = null;
            try
            {
                //É bom aplicar um filtro nessa situação também
                 produtos = await _appDbContext.Produtos.AsNoTracking().Where(c => c.ProdutoId == 1).Include(p => p.Categoria).ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu erro ao tratar sua solicitação.");
            }

            if (produtos == null)
                return NotFound("Produtos não encontrados.");

            return produtos;
        }

        //Restrição de Rotas
        //adiciona parâmetros e restrições a serem observadas na rota.
        //[HttpGet("{id:int}/{param = Teste}", Name = "ObterProduto")] -> Parâmetro de rota com valor default.
        [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
        public async Task<ActionResult<Produto>> Get(int id, [BindRequired]string nome) //BindRequered exige o parâmetro nome na Query String
        {
            Produto? produto = null;

            try
            {
                produto = await _appDbContext.Produtos.AsNoTracking().FirstOrDefaultAsync(produto => produto.ProdutoId == id);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu erro ao tratar sua solicitação.");
            }

            if (produto == null)
                return NotFound("Produto não encontrado.");

            return produto;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            if (produto == null)
                return BadRequest();
                        
            //Caso a validação dos dos dados feita por atributos data annotations não esteja sendo feita automaticamente.
            /*
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */

            try
            {
                _appDbContext.Produtos.Add(produto);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu erro ao tratar sua solicitação.");
            }

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        //Atualização completa do objeto.
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }

            try
            {
                //Indica que a entidade precisa ser persistida
                _appDbContext.Entry(produto).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu erro ao tratar sua solicitação.");
            }

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var produto = _appDbContext.Produtos.FirstOrDefault(p => p.ProdutoId == id);

            //Primeiro tenta localizar na memória. id deve ser a chave primária
            //var produto = _appDbContext.Produtos.Find(id);
            
            if (produto == null)
                return NotFound("Produto não encontrado.");

            try
            {
                _appDbContext.Produtos.Remove(produto);
                _appDbContext.SaveChanges();
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocoreu erro ao tratar sua solicitação.");
            }

            return Ok(produto);
        }
    }
}
