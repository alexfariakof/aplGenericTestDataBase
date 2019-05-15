using GenericTestDataBase.Models;

namespace Business
{
    public interface IControleAcessoBusiness
    {
        object FindByLogin(ControleAcesso controleAcesso);
        bool Create(Usuario usuario, ControleAcesso controleAcesso);
        bool RecoveryPassword(string email);
    }
}
