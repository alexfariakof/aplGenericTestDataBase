using GenericTestDataBase.Models.Base;

namespace GenericTestDataBase.Models
{
    public class Tarefa : BaseEntity
    {
        public virtual Usuario usuario { get; set; }
        public string Descricao { get; set; }        
    }
}