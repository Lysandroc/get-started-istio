using System;
using System.Collections.Generic;
using System.Linq;
using ApiRelatorios.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRelatorios.Repositories
{
    public class RelatoriosRepository : DbContext
    {
        public RelatoriosRepository(DbContextOptions<RelatoriosRepository> options)
            : base(options)
        {
        }

        public DbSet<Relatorio> Relatorios { get; set; }
    }
}