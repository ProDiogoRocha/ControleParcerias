using System.Collections.Generic;

namespace ControleDeParcerias.Data.Interfaces.Servicos
{
    public interface IService<T> where T : class
    {
        IList<T> GetTodos();
        T GetPorId(int Id);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(int Id);
        void Dispose();
        bool VerificarNomeTitulo(string titulo);
    }
}
