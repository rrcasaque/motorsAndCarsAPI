using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication1.Controllers.v1
{

    [Route("api/v1/GetMotorista")]
    public class GetMotoristaController : ApiController
    {
        public async Task<HttpResponseMessage> Get()
        {
            HttpResponseMessage response;
            WebApplication1.Classes.Json.GetMotoristaResponse getMotoristaResponse = new WebApplication1.Classes.Json.GetMotoristaResponse();
            string jsonResponse = string.Empty;

            try
            {
                Classes.Database database = new Classes.Database();


                getMotoristaResponse = database.ListarTodosMotoristas();
                jsonResponse = JsonConvert.SerializeObject(getMotoristaResponse).ToString();

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
