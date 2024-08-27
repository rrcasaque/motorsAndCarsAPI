using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Classes.Json
{
    public class GetCarroResponse
    {
        [JsonProperty("carros")]
        public List<CarrosList> Carros { get; set; }

        public partial class CarrosList
        {
            [JsonProperty("carroID")]
            public int CarroID { get; set; }

            [JsonProperty("placa")]
            public string Placa { get; set; }

            [JsonProperty("marca")]
            public string Marca { get; set; }

            [JsonProperty("anoFabricacao")]
            public int AnoFabricacao { get; set; }

            [JsonProperty("cor")]
            public string Cor { get; set; }

            [JsonProperty("motoristaNome")]
            public string MotoristaNome { get; set; }

            [JsonProperty("motoristaEmail")]
            public string MotoristaEmail { get; set; }

            [JsonProperty("motoristaCPF")]
            public string MotoristaCPF { get; set; }
        }        

    }
}