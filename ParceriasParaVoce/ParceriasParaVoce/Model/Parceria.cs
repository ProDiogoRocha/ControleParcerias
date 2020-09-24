using Newtonsoft.Json;
using System;

namespace ParceriasParaVoce.Model
{
    public class Parceria
    {
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