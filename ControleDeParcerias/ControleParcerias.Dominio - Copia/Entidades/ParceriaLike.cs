using System;
using System.ComponentModel.DataAnnotations;

namespace ControleParcerias.Dominio.Entidades
{
    public class ParceriaLike
    {
        [Key]
        public int Codigo { get; set; }
        public int CodigoParceria { get; set; }
        public DateTime DataHoraCadastro { get; set; }
    }
}
