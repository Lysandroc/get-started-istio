using System;
using System.Collections.Generic;
using System.Linq;
using ApiSolicitacaoRelatorios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiSolicitacaoRelatorios.Repositories
{
    public class SolicitacoesRepository : DbContext
    {
        public SolicitacoesRepository(DbContextOptions<SolicitacoesRepository> options)
            : base(options)
        {
        }

        public DbSet<Solicitacao> Solicitacoes { get; set; }    
    }
}