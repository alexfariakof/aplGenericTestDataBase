using GenericTestDataBase.Models.Base;
using System.Collections.Generic;

namespace GenericTestDataBase.Repositorio
{
    public interface IRepositorio<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(int id);
        List<T> FindAll();
        T Update(T item);
        void Delete(T item);

        bool Exists(int? id);
    }
}