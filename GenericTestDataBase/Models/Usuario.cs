using GenericTestDataBase.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenericTestDataBase.Models
{
    public class Usuario : BaseEntity
    {
        [StringLength(30)]
        public string Nome { get; set; }
        [StringLength(50)]
        public string SobreNome { get; set; }
        [StringLength(11)]
        public string Telefone { get; set; }
        [StringLength(50)]
        public string Email { get; set;  }
        [StringLength(8)]
        public string Senha { get; set; }
        public virtual Permissao Permissao { get; set; }
        public virtual List<Tarefa> Tarefas { get; set; }
        public virtual List<Receita> Receitas { get; set; }
        public virtual List<Despesa> Despesas { get; set; }
    }
}
