using GenericTestDataBase.Models;

namespace GenericTestDataBase.Repositorio
{
    public interface IControleAcessoRepositorio
    { 
        ControleAcesso FindByLogin(string login);
        Usuario GetUsuarioByLogin(string login);
        bool  Create(Usuario usuario, ControleAcesso controleAcesso);
        bool RecoveryPassword(string email);

    }
}
