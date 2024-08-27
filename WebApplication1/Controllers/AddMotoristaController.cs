using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication1.Classes;
using WebApplication1.Classes.Json;

namespace WebApplication1.Controllers.v1
{

    [Route("api/v1/AddMotorista")]
    public class AddMotosristaController : ApiController
    {
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] JObject _addMotoristaRequest)
        {
            HttpResponseMessage response;
            WebApplication1.Classes.Json.HelloWorldResponse helloWorldResponse = new WebApplication1.Classes.Json.HelloWorldResponse();
            string jsonResponse = string.Empty;

            Database database = new Database();

            try
            {
                WebApplication1.Classes.Json.AddMotoristaRequest addMotoristaRequest =
                    JsonConvert.DeserializeObject<WebApplication1.Classes.Json.AddMotoristaRequest>(_addMotoristaRequest.ToString());

                if (addMotoristaRequest == null || string.IsNullOrEmpty(addMotoristaRequest.Telefone) || string.IsNullOrEmpty(addMotoristaRequest.Nome) || string.IsNullOrEmpty(addMotoristaRequest.Endereco) || string.IsNullOrEmpty(addMotoristaRequest.DataNascimento) || string.IsNullOrEmpty(addMotoristaRequest.CPF) || string.IsNullOrEmpty(addMotoristaRequest.Email))
                {
                    helloWorldResponse.Message = "Necessário informar todos os parâmetros";
                    jsonResponse = JsonConvert.SerializeObject(helloWorldResponse).ToString();

                    response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                    response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                    return response;
                }                

                if(!database.InserirMotorista(addMotoristaRequest.Nome, addMotoristaRequest.CPF, DateTime.Parse(addMotoristaRequest.DataNascimento), addMotoristaRequest.Endereco, addMotoristaRequest.Telefone, addMotoristaRequest.Email))
                {
                    helloWorldResponse.Message = "Houve algum erro!";                    
                    jsonResponse = JsonConvert.SerializeObject(helloWorldResponse).ToString();
                    response = Request.CreateResponse(System.Net.HttpStatusCode.BadRequest);
                    response.Content = new StringContent(jsonResponse, Encoding.UTF8, "application/json");
                    return response;
                }

                helloWorldResponse.Message = "Motorista inserido com sucesso!";
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
