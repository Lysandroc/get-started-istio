using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiSolicitacaoRelatorios.Models;
using ApiSolicitacaoRelatorios.ModelViews;
using ApiSolicitacaoRelatorios.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiSolicitacaoSolicitacaos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacoesController : ControllerBase
    {
        private readonly SolicitacoesRepository _solicitacoesRepository;
        static HttpClient client = new HttpClient();
        public SolicitacoesController(SolicitacoesRepository SolicitacaosRepository) 
        {
            this._solicitacoesRepository = SolicitacaosRepository;
            
        }
        // GET api/Solicitacaos
        [HttpGet]
        public ActionResult<IEnumerable<Solicitacao>> GetSolicitacaos()
        {
            return Ok(this._solicitacoesRepository.Solicitacoes.ToList());        
        }

        // GET api/Solicitacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitacao>> GetSolicitacao(Int64 id)
        {
            var solicitacao = await _solicitacoesRepository.Solicitacoes.FindAsync(id);

            if (solicitacao == null)
            {
                return NotFound();
            }

            return solicitacao;
        }

        [HttpPost]
        public async Task<ActionResult<Solicitacao>> PostSolicitacao(SolicitacaoModelView modelView)
        {
            var solicitacao = new Solicitacao();
            solicitacao.EmailSolicitante = modelView.EmailSolicitante;
            solicitacao.Filtros = modelView.Filtros;
            solicitacao.IdRelatorio = modelView.IdRelatorio;

            _solicitacoesRepository.Solicitacoes.Add(solicitacao);
            await _solicitacoesRepository.SaveChangesAsync();

            return CreatedAtAction("GetSolicitacao", new { id = solicitacao.Id }, solicitacao);
        }
        
        [HttpGet("{id}/relatorio")]
        public async Task<ActionResult<Relatorio>> GetRelatorio(Int64 id) {
            var solicitacao = await this._solicitacoesRepository.Solicitacoes.FindAsync(id);
            Relatorio relatorio = null;

            HttpResponseMessage response = await client.GetAsync($"http://relatorios/api/relatorios/{solicitacao.IdRelatorio}");
            if (response.IsSuccessStatusCode)
            {
                relatorio = await response.Content.ReadAsAsync<Relatorio>();
            }
            return relatorio;
        }

    }
}

