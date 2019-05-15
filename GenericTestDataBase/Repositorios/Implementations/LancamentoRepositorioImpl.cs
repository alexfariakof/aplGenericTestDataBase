using apiDespesasPessoais.VO;
using GenericTestDataBase.Models.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GenericTestDataBase.Repositorio.Implementations
{
    public class LancamentoRepositorioImpl : ILancamentoRepositorio
    {
        private readonly MsSqlContext _context;

        public LancamentoRepositorioImpl()
        {
            _context = new MsSqlContext();
        }

        public List<LancamentoVO> FindByMesAno(DateTime data, int idUsuario)
        {
            int mes = data.Month;
            int ano = data.Year;

            string sql = "Select ABS(Checksum(NewId()) %10000) as id, lancamentos.* From ( " + 
                         "Select d.idUsuario, data, idCategoria, valor*-1 as valor, d.id as idDespesa, 0 as idReceita, d.descricao, c.descricao as categoria " +
                         "  FROM Despesa d " +
                         " Inner Join Categoria c on d.idCategoria = c.id " +
                         " where d.idUsuario = @idUsuario " +
                         "   and Month(data) = @mes " +
                         "   and  Year(data) = @ano " +
                         " union " +
                         "Select r.idUsuario, data, idCategoria, valor,0 as idDespesa, r.id as idReceita, r.descricao, c.descricao as categoria " +
                         "  FROM Receita r " +
                         " Inner Join Categoria c on r.idCategoria = c.id " +
                         " where r.idUsuario = @idUsuario " +
                         "   and Month(data) = @mes " +
                         "   and  Year(data) = @ano " +
                         ") lancamentos ";


            using (_context)
            {
                try
                {
                    var list = _context.Database.SqlQuery<LancamentoVO>(sql).ToList();
                    return list.OrderBy(item => item.Data).ThenBy(item => item.Categoria).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public decimal GetSaldo(int idUsuario)
        {
            using (_context)
            {
                decimal value = 0;
                try
                {
                    string sql = @"Select (SELECT sum(valor) FROM Receita Where idUsuario = @idUsuario) - (SELECT sum(valor) FROM Despesa Where idUsuario = @idUsuario)";

                    var saldo = _context.Database.SqlQuery<LancamentoVO>(sql, new SqlParameter("@idUsuario", idUsuario)).ToString();
                    decimal.TryParse(saldo, out value);
                    return value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}

