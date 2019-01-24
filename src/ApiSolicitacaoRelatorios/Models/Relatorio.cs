using System;

namespace ApiSolicitacaoRelatorios.Models
{
    public class Relatorio
    {
        public Relatorio(Int64 id, String nome, String descricao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
        }

        public Int64 Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
    }
}