using System;
using GenericTestDataBase.Models;
using GenericTestDataBase.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestGenericDataBase
{
    [TestClass]
    public class UnitTestModels
    {
        [TestMethod]
        public void TestCreateUsaurio()
        {
            Usuario usuario = new Usuario {
                Nome = "Alex Ribeiro",
                SobreNome = "Ribeir de Faria",
                Email = "alexfariakof@gmail.com",
                Telefone = "219928793190"                
            };

            IRepositorio <Usuario> repositorio = new GenericRepositorio<Usuario>();
            bool resut = repositorio.Create(usuario) != null ? true : false;
        }
    }
}
