using GenericTestDataBase.Models.Base;
using System;

namespace GenericTestDataBase.Models
{
    public class Receita : BaseEntity
    {
        public Usuario Usuario { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime data { get; set; }
        public String Descricao { get; set; }
        public Decimal Valor { get; set; }
    }
}
