using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Classes.Json
{
    public class HelloWorldResponse
    {
        [JsonProperty("Message")]
        public string Message { get; set; }
    }
}