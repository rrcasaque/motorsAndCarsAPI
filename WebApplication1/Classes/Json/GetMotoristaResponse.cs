using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Classes.Json
{
    public class GetMotoristaResponse
    {
        [JsonProperty("motoristas")]
        public List<MotoristasList> Motoristas { get; set; }

        public partial class MotoristasList
        {
            [JsonProperty("motoristaID")]
            public int MotoristaID { get; set; }

            [JsonProperty("nome")]
            public string Nome { get; set; }

            [JsonProperty("cpf")]
            public string CPF { get; set; }

            [JsonProperty("dataNascimento")]
            public string DataNascimento { get; set; }

            [JsonProperty("endereco")]
            public string Endereco { get; set; }

            [JsonProperty("telefone")]
            public string Telefone { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("dataCadastro")]
            public string DataCadastro { get; set; }            
        }
    }
}