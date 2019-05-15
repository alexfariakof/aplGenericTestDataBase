using GenericTestDataBase.Models.Base;
using System;

namespace GenericTestDataBase.VO
{
    public class RelatorioDespesasReceitasVO : BaseEntity
    {
        public string mes { get; set; }
        public int? despesaMes { get; set; }
        public Decimal? despesaValor { get; set; }
        public int? receitaMes { get; set; }
        public Decimal? receitaValor { get; set; }
    }
}
