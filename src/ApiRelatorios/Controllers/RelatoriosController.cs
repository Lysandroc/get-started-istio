using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRelatorios.Models;
using ApiRelatorios.ModelViews;
using ApiRelatorios.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiRelatorios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly RelatoriosRepository _relatoriosRepository;
        public RelatoriosController(RelatoriosRepository relatoriosRepository) 
        {
            this._relatoriosRepository = relatoriosRepository;
            if (_relatoriosRepository.Relatorios.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _relatoriosRepository.Relatorios.Add(new Relatorio { Nome = "VENDAS GERAL", Descricao = "Relatório de Vendas Geral" });
                _relatoriosRepository.SaveChanges();
            }
        }
        // GET api/relatorios
        [HttpGet]
        public ActionResult<IEnumerable<Relatorio>> GetRelatorios()
        {
            return Ok(this._relatoriosRepository.Relatorios.ToList());        
        }

        // GET api/relatorios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Relatorio>> GetRelatorio(Int64 id)
        {
            var relatorio = await _relatoriosRepository.Relatorios.FindAsync(id);

            if (relatorio == null)
            {
                return NotFound();
            }

            return relatorio;
        }

        [HttpPost]
        public async Task<ActionResult<Relatorio>> PostRelatorio(RelatorioModelView modelView)
        {
            var relatorio = new Relatorio();
            relatorio.Nome = modelView.Nome;
            relatorio.Descricao = modelView.Descricao;

            _relatoriosRepository.Relatorios.Add(relatorio);
            await _relatoriosRepository.SaveChangesAsync();

            return CreatedAtAction("GetRelatorio", new { id = relatorio.Id }, relatorio);
        }
    }
}
