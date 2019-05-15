using GenericTestDataBase.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace GenericTestDataBase.Models
{
    public class Despesa : BaseEntity
    {
        public  virtual Usuario Usuario { get; set; }
        public  virtual Categoria Categoria { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [StringLength(50)]
        public String Descricao { get; set; }
        public Decimal Valor { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataVencimento { get; set; }
    }
}
