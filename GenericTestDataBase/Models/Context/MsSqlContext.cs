using System.Data.Entity;

namespace GenericTestDataBase.Models.Context
{
    [DbConfigurationType(typeof(MsSqlConfiguration))]
    public class MsSqlContext : DbContext
    {
        public MsSqlContext() { }

        public DbSet<Categoria> CategoriaTB { get; set; }
        public DbSet<ControleAcesso> ControleAcessoTB { get; set; }        
        public DbSet<Despesa> DespesaTB { get; set; }
        public DbSet<Permissao> PermissaoTB { get; set; }
        public DbSet<Receita> ReceitaTB { get; set; }
        public DbSet<Tarefa> TarefaTB { get; set; }
        public DbSet<Usuario> UsuarioTB { get; set; }              
        public DbSet<TipoCategoria> TipoCategoriaTB { get; set; }
    }
}