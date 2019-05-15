﻿using Business.Generic;
using GenericTestDataBase.Models;
using GenericTestDataBase.Repositorio;
using System.Collections.Generic;

namespace apiReceitasPessoais.Business.Implementations
{
    public class ReceitaBusinessImpl : IBusiness<Receita>
    {
        private readonly IRepositorio<Receita> _repositorio;

        public ReceitaBusinessImpl(IRepositorio<Receita> repositorio)
        {
            _repositorio = repositorio;
        }
        public Receita Create(Receita obj)
        {
            return _repositorio.Create(obj);
        }

        public List<Receita> FindAll()
        {
            return _repositorio.FindAll();
        }      

        public Receita FindById(int id)
        {
            return _repositorio.FindById(id);
        }

        public Receita Update(Receita obj)
        {           

            return _repositorio.Update(obj);
        }

        public void Delete(Receita receita)
        {
            _repositorio.Delete(receita);
        }

    }
}
