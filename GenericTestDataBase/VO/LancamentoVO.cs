using System;

namespace apiDespesasPessoais.VO
{
    public class LancamentoVO
    {
        public int ID { get; set; }
        public int IdUsuario { get; set; }
        public int IdDespesa { get; set; }
        public int IdReceita { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }

    }
}
