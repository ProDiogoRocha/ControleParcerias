using ControleParcerias.Dominio.Entidades;

namespace ControleDeParcerias.Data.Interfaces.Repositorios
{
    public interface IParceriaLikeRepository
    {
        ParceriaLike BuscarParceriaLikePorCodigoParceria(int codigoParceria);
        void Dispose();
    }
}
