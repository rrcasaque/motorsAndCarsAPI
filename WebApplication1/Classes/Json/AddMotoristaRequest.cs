using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Classes.Json
{
    public class AddMotoristaRequest
    {
        [JsonProperty("Nome")]
        public string Nome { get; set; }

        [JsonProperty("CPF")]
        public string CPF { get; set; }

        [JsonProperty("DataNascimento")]
        public string DataNascimento { get; set; }

        [JsonProperty("Endereco")]
        public string Endereco { get; set; }

        [JsonProperty("Telefone")]
        public string Telefone { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }        
    }
}