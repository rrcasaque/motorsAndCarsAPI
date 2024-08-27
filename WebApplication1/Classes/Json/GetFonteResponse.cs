using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static WebApplication1.Classes.Json.GetCarroResponse;

namespace WebApplication1.Classes.Json
{
    public class GetFonteResponse
    {

        [JsonProperty("fontes")]
        public List<FontesList> fontes { get; set; }

        public partial class FontesList
        {
            [JsonProperty("fonteID")]
            public int fonteID { get; set; }

            [JsonProperty("parametros")]
            public string parametros { get; set; }
        }        
    }
}