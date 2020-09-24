using Dapper;
using ParceriaWebAPI.Dominio.Entidades;
using ParceriaWebAPI.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ParceriaWebAPI.Repositorio.Repositorios
{
    public class ParceriaRepository : IParceriaRepository
    {

        private SqlConnection sqlCon;
        private string sqlConnection;

        public ParceriaRepository()
        {
            sqlConnection = ConfigurationManager.ConnectionStrings["RHParceriasBeneficios"].ToString();
            sqlCon = new SqlConnection(sqlConnection);
        }
        public void CadastraLike(int Id)
        {
            sqlCon.Execute("spParceriaLike", new { @CodigoParceria = Id}, null, null, commandType: CommandType.StoredProcedure);
        }

        public void Commit()
        {
            sqlCon.Close();
        }

        public void Dispose()
        {
            sqlCon.Dispose();
        }

        public void Open()
        {
            sqlCon.Open();
        }

        public IList<Parceria> PesquisaParceria(string pesquisa)
        {
            return sqlCon.Query<Parceria>($@"select * from vParceria where GETDATE() > DataInicio AND GETDATE() < DataTermino AND (Titulo = '{pesquisa}' OR Empresa = '{pesquisa}')").ToList();
        }

        public IList<Parceria> RetornaLista()
        {
            return sqlCon.Query<Parceria>("select * from vParceria where GETDATE() > DataInicio AND GETDATE() < DataTermino").ToList();
        }

        public Parceria RetornaParceria(int Id)
        { 
            return sqlCon.Query<Parceria>($@"select * from vParceria where Codigo = {Id}").FirstOrDefault();
        }
    }
}
