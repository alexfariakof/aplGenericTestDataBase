using Business.Generic;
using GenericTestDataBase.Models;
using GenericTestDataBase.Repositorio;
using System.Collections.Generic;

namespace Business.Implementations
{
    public class DespesaBusinessImpl : IBusiness<Despesa>
    {
        private readonly IRepositorio<Despesa> _repositorio;

        public DespesaBusinessImpl(IRepositorio<Despesa> repositorio)
        {
            _repositorio = repositorio;
        }
        public Despesa Create(Despesa obj)
        {
            return _repositorio.Create(obj);
        }

        public List<Despesa> FindAll()
        {
            return _repositorio.FindAll();
        }      

        public Despesa FindById(int id)
        {
            return _repositorio.FindById(id);
        }

        public Despesa Update(Despesa obj)
        {           

            return _repositorio.Update(obj);
        }

        public void Delete(Despesa despesa)
        {
            _repositorio.Delete(despesa);
        }

    }
}
