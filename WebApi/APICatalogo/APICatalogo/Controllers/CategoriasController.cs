using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Services;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        //Uma forma de instanciar um serviço via injeção de dependência.
        //private readonly IMeuServico _meuServico;

        public CategoriasController(AppDbContext context /*, IMeuServico meuServico*/)
        {
            _context = context;
            //_meuServico = meuServico;
        }


        //meuServico é instanciado via injeção de dependência. Não há necessidade do atributo from services.
        [HttpGet("fromservices/{nome}")]
        public ActionResult<string> GetSaudacao(IMeuServico meuServico, string nome)
        {
            return meuServico.Saudacao(nome);
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            //Nunca retorne todos os registros
            return await _context.Categorias.AsNoTracking().Take(10).ToListAsync();
        }

        [HttpGet ("produtos")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasComProdutos()
        {
            //É bom aplicar um filtro nessa situação também
            return await _context.Categorias.AsNoTracking().Where(c => c.CategoriaId == 2).Include(p => p.Produtos).ToListAsync();
        }


        // GET: Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        // DELETE: Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }
    }
}
