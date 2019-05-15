using GenericTestDataBase.Models.Context;
using GenericTestDataBase.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GenericTestDataBase.Repositorio.Implementations
{
    public class RelatorioRepositorioImpl : IRelatorioRepositorio
    {
        private readonly MsSqlContext _context;

        public RelatorioRepositorioImpl()
        {
            _context = new MsSqlContext();
        }

        public List<RelatorioDespesasReceitasVO> GetRelatorioUsuarioByAno(int idUsuario, int ano)
        {
            string sql = " DECLARE @meses TABLE(id INT, mes varchar(3)) " +
                         " insert into @meses values(1,'JAN'), (2, 'FEV'), (3, 'MAR'), (4, 'ABR'), (5, 'MAI'), (6, 'JUN'), (7, 'JUL'), (8, 'AGO'), (9, 'SET'), (10, 'OUT'), (11, 'NOV'), (12, 'DEZ') " +
                         "Select * From " +
                         "(Select id, mes From @meses) meses " +
                         "  Left join " +
                         "  (Select Month(data) as despesaMes, sum(valor) as despesaValor From despesa where idUsuario = @idUsuario  and year(data) = @ano " +
                         "    Group by Month(data)) d on meses.id = d.despesaMes " +
                         "  Left Join " +
                         "  (Select Month(data) as receitaMes, sum(valor) as receitaValor From receita where idUsuario = @idUsuario  and year(data) = @ano " +
                         "    Group by Month(data)) r on meses.id = r.receitaMes ";

            using (_context)
            {
                try
                {
                    return _context.Database.SqlQuery<RelatorioDespesasReceitasVO>(sql).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public decimal GetTotalDespesaUsuarioByAno(int idUsuario, int ano)
        {
            using (_context)
            {
                decimal value = 0;
                try
                {
                    string sql = @"SELECT  sum(valor)  FROM Despesa where idUsuario = @idUsuario  and year(data) = @ano";

                    var total = _context.Database.SqlQuery<RelatorioDespesasReceitasVO>(sql, new SqlParameter("@idUsuario", idUsuario), new SqlParameter("@ano", ano)).ToString();
                    decimal.TryParse(total, out value);
                    return value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public decimal GetTotalReceitaUsaurioByAno(int idUsuario, int ano)
        {
            using (_context)
            {
                decimal value = 0;
                try
                {
                    string sql = @"SELECT  sum(valor)  FROM Receita where idUsuario = @idUsuario  and year(data) = @ano";

                    var total = _context.Database.SqlQuery<RelatorioDespesasReceitasVO>(sql, new SqlParameter("@idUsuario", idUsuario), new SqlParameter("@ano", ano)).ToString();
                    decimal.TryParse(total, out value);
                    return value;
                }
                catch(Exception ex )
                {
                    throw ex;
                }
            }
        }
    }
}
