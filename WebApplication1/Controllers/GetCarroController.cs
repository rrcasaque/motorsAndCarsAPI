using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Classes.Json;

namespace WebApplication1.Controllers.v1
{

    [Route("api/v1/GetCarro")]
    public class GetCarroController : ApiController
    {
        public async Task<HttpResponseMessage> Get([FromBody] JObject _getCarroRequest)
        {
            WebApplication1.Classes.Json.GetCarroRequest getCarroRequest =
                    JsonConvert.DeserializeObject<WebApplication1.Classes.Json.GetCarroRequest>(_getCarroRequest.ToString());

            HttpResponseMessage response;
            WebApplication1.Classes.Json.GetCarroResponse getCarroResponse = new WebApplication1.Classes.Json.GetCarroResponse();
            string jsonResponse = string.Empty;

            try
            {
                Classes.Database database = new Classes.Database();

                getCarroResponse = database.ListarTodosCarros();

                if (!getCarroRequest.filterUser.IsNullOrWhiteSpace())
                {
                     getCarroResponse.Carros = getCarroResponse.Carros
                    .Where(carro => carro.MotoristaNome == getCarroRequest.filterUser)
                    .ToList();                    
                }

                if (!getCarroRequest.orderType.IsNullOrWhiteSpace())
                {
                    switch (getCarroRequest.orderType) {
                        case "anoFabricacao":
                             getCarroResponse.Carros = getCarroResponse.Carros
                            .OrderBy(carro => carro.AnoFabricacao)
                            .ToList();                                                        
                            break;
                        case "marca":
                            getCarroResponse.Carros = getCarroResponse.Carros
                            .OrderBy(carro => carro.Marca)
                            .ToList();
                            break;
                        case "motoristaNome":
                            getCarroResponse.Carros = getCarroResponse.Carros
                            .OrderBy(carro => carro.MotoristaNome)
                            .ToList();
                            break;
                    }
                }
                
                jsonResponse = JsonConvert.SerializeObject(getCarroResponse).ToString();

                Console.WriteLine(database.ListarTodosMotoristas());

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
