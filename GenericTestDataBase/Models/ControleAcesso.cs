using GenericTestDataBase.Models.Base;

namespace GenericTestDataBase.Models
{
    public class ControleAcesso : BaseEntity
    {
        public virtual Usuario usuario { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
