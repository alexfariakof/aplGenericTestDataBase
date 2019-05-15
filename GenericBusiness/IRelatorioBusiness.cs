using GenericTestDataBase.VO;
using System.Collections.Generic;

namespace Business
{
    public interface IRelatorioBusiness
    {
        decimal GetTotalDespesaUsuarioByAno(int idUsuario, int ano);
        decimal GetTotalReceitaUsaurioByAno(int idUsuario, int ano);
        List<RelatorioDespesasReceitasVO> GetRelatorioUsuarioByAno(int idUsuario, int ano);
    }
}
