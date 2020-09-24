using ControleDeParcerias.Data.Interfaces.Repositorios;
using ControleDeParcerias.Data.Interfaces.Servicos;
using ControleParcerias.Dominio.Entidades;
using System.Collections.Generic;

namespace ControleDeParcerias.Servico.Servicos
{
    public class ParceriaService : IParceriaService
    {
        private readonly IParceriaRepository _parceriaRepository;
        private readonly IParceriaLikeRepository _parceriaLikeRepository;
        public ParceriaService(IParceriaRepository parceriaRepository, IParceriaLikeRepository parceriaLikeRepository)
        {
            _parceriaRepository = parceriaRepository;
            _parceriaLikeRepository = parceriaLikeRepository;
        }
        public void Adicionar(Parceria entity)
        {
            _parceriaRepository.Open();
            _parceriaRepository.Adicionar(entity);
            _parceriaRepository.Commit();
        }

        public void Atualizar(Parceria entity)
        {
            _parceriaRepository.Open();
            _parceriaRepository.Atualizar(entity);
            _parceriaRepository.Commit();
        }

        public void Deletar(int Id)
        {
            if(_parceriaLikeRepository.BuscarParceriaLikePorCodigoParceria(Id) == null)
            {
                _parceriaRepository.Open();
                _parceriaRepository.Deletar(Id);
                _parceriaRepository.Commit();
            }
        }

        public void Dispose()
        {
            _parceriaRepository.Dispose();
        }

        public Parceria GetPorId(int Id)
        {
            _parceriaRepository.Open();
            Parceria parceria = _parceriaRepository.GetPorId(Id);
            _parceriaRepository.Commit();

            return parceria;
        }

        public IList<Parceria> GetTodos()
        {
            _parceriaRepository.Open();
            IList<Parceria> parcerias = _parceriaRepository.GetTodos();
            _parceriaRepository.Commit();

            return parcerias;
        }

        public bool VerificarNomeTitulo(string titulo)
        {
            _parceriaRepository.Open();
            bool retorno = _parceriaRepository.VerificarNomeTitulo(titulo);
            _parceriaRepository.Commit();

            return retorno;
        }
    }
}
