using System.Collections.Generic;

namespace ControleDeParcerias.Data.Interfaces.Repositorios
{
    public interface IRepository<T> where T: class
    {
        IList<T> GetTodos();
        T GetPorId(int Id);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(int Id);
        void Commit();
        void Open();
        void Dispose();
        bool VerificarNomeTitulo(string titulo);
    }
}
