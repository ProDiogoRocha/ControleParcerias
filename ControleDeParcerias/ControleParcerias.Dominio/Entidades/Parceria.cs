using ControleParcerias.Dominio.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleParcerias.Dominio.Entidades
{
    public class Parceria : IBaseEntity
    {
        [Key]
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string URLPagina { get; set; }
        public string Empresa { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int QtdLikes { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}
