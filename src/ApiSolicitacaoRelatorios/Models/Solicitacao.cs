using System;

namespace ApiSolicitacaoRelatorios.Models
{
    public class Solicitacao
    {
        public Int64 Id { get; set; }
        public String EmailSolicitante { get; set; }
        public String Filtros { get; set; }
        public Int64 IdRelatorio { get; set; }
        public Solicitacao()
        {
            
        }
    }
}