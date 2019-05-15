using apiDespesasPessoais.VO;
using System;
using System.Collections.Generic;

namespace Business
{
    public interface ILancamentoBusiness
    {
        List<LancamentoVO> FindByMesAno(DateTime data, int idUsuario);
        decimal GetSaldo(int idUsuario);
    }
}
