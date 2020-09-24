using ControleDeParcerias.Data.Interfaces.Repositorios;
using ControleParcerias.Dominio.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ControleDeParcerias.Data.Repositorios
{
    public class ParceriaRepository : IDisposable, IParceriaRepository
    {
        private SqlConnection sqlCon;
        private string sqlConnection;

        public ParceriaRepository()
        {
            sqlConnection = ConfigurationManager.ConnectionStrings["RHParceriasBeneficios"].ToString();
            sqlCon = new SqlConnection(sqlConnection);
        }

        public void Adicionar(Parceria entity)
        {
            sqlCon.Execute("spParceria", CarregarregarParametros(entity, "INSERT"), null, null, commandType: CommandType.StoredProcedure);
        }

        public void Atualizar(Parceria entity)
        {
            sqlCon.Execute("spParceria", CarregarregarParametros(entity, "UPDATE"), null, null, commandType: CommandType.StoredProcedure);
        }

        public void Commit()
        {
            sqlCon.Close();
        }

        public void Deletar(int Id)
        {
            Parceria entity = GetPorId(Id);

            sqlCon.Execute("spParceria", CarregarregarParametros(entity, "DELETE"), null, null, commandType: CommandType.StoredProcedure);
        }

        public void Dispose()
        {
            sqlCon.Dispose();
        }

        public Parceria GetPorId(int Id)
        {
            return sqlCon.Query<Parceria>($@"Select * from vParceria where Codigo = {Id}").FirstOrDefault();
        }

        public IList<Parceria> GetTodos()
        {
            return sqlCon.Query<Parceria>("Select * from vParceria").ToList();
        }

        public void Open()
        {
            sqlCon.Open();
        }

        public bool VerificarNomeTitulo(string titulo)
        {
            Parceria parceria = null;
            parceria = sqlCon.Query<Parceria>($@"Select * from vParceria where Titulo = '{titulo}'").FirstOrDefault();

            return parceria != null ? true : false;
        }

        private DynamicParameters CarregarregarParametros(Parceria entity, string tipoTransacao)
        {
            var param = new DynamicParameters();
            param.Add("@Codigo", entity.Codigo);
            param.Add("@Titulo", entity.Titulo);
            param.Add("@Descricao", entity.Descricao);
            param.Add("@URLPagina", entity.URLPagina);
            param.Add("@Empresa", entity.Empresa);
            param.Add("@DataInicio", entity.DataInicio.Date);
            param.Add("@DataTermino", entity.DataTermino.Date);
            param.Add("@QtdLikes", entity.QtdLikes);
            param.Add("@DataHoraCadastro", entity.DataHoraCadastro);
            param.Add("@TipoTransacao", tipoTransacao);

            return param;
        }
    }
}
