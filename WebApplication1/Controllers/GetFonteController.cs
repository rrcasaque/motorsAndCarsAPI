using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Classes.Json;

namespace WebApplication1.Controllers.v1
{
    [Route("api/v1/GetFonte")]
    public class GetFonteController : ApiController
    {
        public async Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response;
            GetFonteResponse getFonteResponse = new GetFonteResponse();
            string jsonResponse = string.Empty;

            try
            {
                // Obtém os dados da base de dados
                Classes.Database database = new Classes.Database();
                getFonteResponse = database.ListarTodasFontes();

                // Cria a estrutura hierárquica
                var fontesHierarquizadas = new Dictionary<string, Dictionary<string, Dictionary<string, List<object>>>>();

                foreach (var fonte in getFonteResponse.fontes)
                {
                    // Separa os parâmetros
                    var parametros = fonte.parametros.Split('-');
                    var categoria = parametros[0];
                    var subCategoria = parametros[1].Replace(" ", "_"); // Substitui espaços por underlines
                    var tipo = parametros[2];
                    var nomeFonte = parametros[3];

                    // Cria a hierarquia
                    if (!fontesHierarquizadas.ContainsKey(categoria))
                    {
                        fontesHierarquizadas[categoria] = new Dictionary<string, Dictionary<string, List<object>>>();
                    }

                    if (!fontesHierarquizadas[categoria].ContainsKey(subCategoria))
                    {
                        fontesHierarquizadas[categoria][subCategoria] = new Dictionary<string, List<object>>();
                    }

                    if (!fontesHierarquizadas[categoria][subCategoria].ContainsKey(tipo))
                    {
                        fontesHierarquizadas[categoria][subCategoria][tipo] = new List<object>();
                    }

                    fontesHierarquizadas[categoria][subCategoria][tipo].Add(new { fonte = nomeFonte, fonteID = fonte.fonteID });
                }

                // Serializa a resposta em JSON
                jsonResponse = JsonConvert.SerializeObject(new { fontes = fontesHierarquizadas }, Formatting.Indented);

                // Cria a resposta HTTP
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                jsonResponse = JsonConvert.SerializeObject("Não foi possível processar a solicitação").ToString();
                response = Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            }

            return response;
        }
    }
}
