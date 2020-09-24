using Newtonsoft.Json;
using ParceriaWebAPI.Dominio.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace ParceriaWebAPI.Dominio.Entidades
{
    [Serializable]
    public class Parceria : IEntidadeBase
    {
        [Key]
        [JsonProperty("Codigo")]
        public int Codigo { get; set; }
        
        [JsonProperty("Titulo")]
        public string Titulo { get; set; }
        
        [JsonProperty("Descricao")]
        public string Descricao { get; set; }

        [JsonProperty("URLPagina")]
        public string URLPagina { get; set; }

        [JsonProperty("Empresa")]
        public string Empresa { get; set; }

        [JsonProperty("DataInicio")]
        public DateTime DataInicio { get; set; }

        [JsonProperty("DataTermino")]
        public DateTime DataTermino { get; set; }

        [JsonProperty("QtdLikes")]
        public int QtdLikes { get; set; }

        [JsonProperty("DataHoraCadastro")]
        public DateTime DataHoraCadastro { get; set; }
    }
}
