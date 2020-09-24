using System.Collections.Generic;

namespace ParceriaWebAPI.Repositorio.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IList<T> RetornaLista();
        IList<T> PesquisaParceria(string pesquisa);
        T RetornaParceria(int Id);
        void CadastraLike (int Id);
        void Commit();
        void Open();
        void Dispose();
    }
}
