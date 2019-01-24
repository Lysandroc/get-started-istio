using System;

namespace ApiSolicitacaoRelatorios.ModelViews
{
    public class SolicitacaoModelView
    {
        public String EmailSolicitante { get; set; }
        public String Filtros { get; set; }
        public Int64 IdRelatorio { get; set; }
    }
}