using GenericTestDataBase.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace GenericTestDataBase.Models
{
    public class Categoria : BaseEntity
    {
        public virtual Usuario Usuario { get; set; }
        public TipoCategoria TipoCategoria { get; set; }

        [StringLength(30)]
        public string Descricao { get; set; }
        
    }
}
