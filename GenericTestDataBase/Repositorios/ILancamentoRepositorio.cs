using apiDespesasPessoais.VO;
using System;
using System.Collections.Generic;

namespace GenericTestDataBase.Repositorio
{
    public interface ILancamentoRepositorio
    {
        List<LancamentoVO> FindByMesAno(DateTime data, int idUsuario);
        decimal GetSaldo(int idUsuario);
    }
}
