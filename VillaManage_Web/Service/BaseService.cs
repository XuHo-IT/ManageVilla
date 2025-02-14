using Newtonsoft.Json;
using System.Text;
using VillaManage;
using VillaManage_Web.Model;
using VillaManage_Web.Service.IService;

namespace VillaManage_Web.Service
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel   { get; set ; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apIRequest)
        {
            try
            {
                var client = httpClient.CreateClient("VillaAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apIRequest.Url);
                if (apIRequest.Data != null)
                {
                    message.Content = new
                        StringContent(JsonConvert.SerializeObject(apIRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                switch (apIRequest.APIType)
                {
                    case SD.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }
                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessagess = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }


        }
    }

}
