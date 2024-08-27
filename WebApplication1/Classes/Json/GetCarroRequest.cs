using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Classes.Json
{
    public class GetCarroRequest
    {
        [JsonProperty("orderType")]
        public string orderType { get; set; }

        [JsonProperty("filterUser")]
        public string filterUser { get; set; }
    }
}