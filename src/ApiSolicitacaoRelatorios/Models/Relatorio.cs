using System;

namespace ApiSolicitacaoRelatorios.Models
{
    public class Relatorio
    {
        public Guid Id {get;set;}
        public String Nome{get;set;}
        public String Descricao{get;set;}
        
        public Relatorio(String nome, String descricao)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Descricao = descricao;
        }
    }
}