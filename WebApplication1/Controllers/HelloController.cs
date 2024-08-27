using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication1.Controllers.v1
{
    
    [Route("api/v1/HelloWorld")]    
    public class HelloWorldController : ApiController
    {
        public async Task<HttpResponseMessage> Get([FromBody] JObject _helloWorldRequest)
        {
            HttpResponseMessage response;
            WebApplication1.Classes.Json.HelloWorldResponse helloWorldResponse = new WebApplication1.Classes.Json.HelloWorldResponse();
            string jsonResponse = string.Empty;

            try
            {                
                WebApplication1.Classes.Json.HelloWorldRequest helloWorldRequest =
                    JsonConvert.DeserializeObject<WebApplication1.Classes.Json.HelloWorldRequest>(_helloWorldRequest.ToString());

                if (helloWorldRequest == null || string.IsNullOrEmpty(helloWorldRequest.Name))
                {
                    helloWorldResponse.Message = "Necessário informar o campo 'Name'";
                    jsonResponse = JsonConvert.SerializeObject(helloWorldResponse).ToString();

                    response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                    response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                    return response;
                }
             
                await Task.Delay(100); // Simulação de latência ou operação assíncrona
                
                helloWorldResponse.Message = $"Olá {helloWorldRequest.Name}";
                jsonResponse = JsonConvert.SerializeObject(helloWorldResponse).ToString();

                response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            }
            catch (Exception ex)
            {
                helloWorldResponse.Message = "Não foi possível processar a solicitação";
                jsonResponse = JsonConvert.SerializeObject(helloWorldResponse).ToString();

                response = Request.CreateResponse(System.Net.HttpStatusCode.InternalServerError);
                response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
            }

            return response;
        }
    }
}
