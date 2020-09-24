using ControleDeParcerias.Data.Interfaces.Repositorios;
using ControleParcerias.Dominio.Entidades;
using Dapper;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace ControleDeParcerias.Data.Repositorios
{
    public class ParceriaLikeRepository : IDisposable, IParceriaLikeRepository
    {
        private SqlConnection sqlCon;
        private string sqlConnection;

        public ParceriaLikeRepository()
        {
            sqlConnection = ConfigurationManager.ConnectionStrings["RHParceriasBeneficios"].ToString();
            sqlCon = new SqlConnection(sqlConnection);
        }

        public ParceriaLike BuscarParceriaLikePorCodigoParceria(int codigoParceria)
        {
            sqlCon.Open();
            ParceriaLike parceriaLike = null;
            parceriaLike = sqlCon.Query<ParceriaLike>($@"Select * from vParceriaLike where CodigoParceria = {codigoParceria}").FirstOrDefault();
            sqlCon.Close();
            return parceriaLike;
        }


        public void Dispose()
        {
            sqlCon.Dispose();
        }
    }
}
