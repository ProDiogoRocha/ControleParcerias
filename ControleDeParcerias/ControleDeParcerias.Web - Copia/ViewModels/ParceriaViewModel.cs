using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeParcerias.Web.ViewModels
{
    public class ParceriaViewModel
    {
        public ParceriaViewModel()
        {
            DataHoraCadastro = DateTime.Now;
        }
        [Key]
        [Display(Name = "Cód. Parceria")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Titulo é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Descrição é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "URL da pagina")]
        public string URLPagina { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Empresa é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Empresa")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Data Inicio é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data Início")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O preenchimento do campo Data Termino é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Data Término")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataTermino { get; set; }

        [Display(Name = "Qtd. Likes")]
        public int QtdLikes { get; set; }
        public DateTime DataHoraCadastro { get; set; } = DateTime.Now;
    }
}