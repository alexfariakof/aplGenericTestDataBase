using Business.Generic;
using GenericTestDataBase.Models;
using GenericTestDataBase.Repositorio;
using System.Collections.Generic;

namespace Business.Implementations
{
    public class CategoriaBusinessImpl : IBusiness<Categoria>
    {
        private readonly IRepositorio<Categoria> _repositorio;

        public CategoriaBusinessImpl()
        {
            _repositorio = new GenericRepositorio<Categoria>();
        }
        public Categoria Create(Categoria obj)
        {
            return _repositorio.Create(obj);
        }

        public List<Categoria> FindAll()
        {
            return _repositorio.FindAll();
        }      

        public Categoria FindById(int id)
        {
            return _repositorio.FindById(id);
        }

        public Categoria Update(Categoria obj)
        {           

            return _repositorio.Update(obj);
        }

        public void Delete(Categoria categoria)
        {
            _repositorio.Delete(categoria);
        }

    }
}
