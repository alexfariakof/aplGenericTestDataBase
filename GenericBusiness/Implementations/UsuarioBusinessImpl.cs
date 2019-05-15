using Business.Generic;
using GenericTestDataBase.Models;
using GenericTestDataBase.Repositorio;
using System.Collections.Generic;

namespace Business.Implementations
{
    public class UsuarioBusinessImpl : IBusiness<Usuario>
    {
        private IRepositorio<Usuario> _repositorio;

        public UsuarioBusinessImpl()
        {
            _repositorio = new GenericRepositorio<Usuario>();            
        }
        public Usuario Create(Usuario usuario)
        {
            return _repositorio.Create(usuario);
        }

        public List<Usuario> FindAll()
        {
            return _repositorio.FindAll();
        }      

        public Usuario FindById(int idUsuario)
        {
            return _repositorio.FindById(idUsuario);
        }

        public Usuario Update(Usuario usuario)
        {           

            return _repositorio.Update(usuario);
        }

        public void Delete(Usuario usuario)
        {
            _repositorio.Delete(usuario);
        }

    }
}
