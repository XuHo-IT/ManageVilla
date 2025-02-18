using Newtonsoft.Json;
using System.Net.Http.Headers;
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
                if (!string.IsNullOrEmpty(apIRequest.Token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apIRequest.Token);
                }
                if (apIRequest.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(apIRequest.Data),
                        Encoding.UTF8,
                        "application/json"
                    );
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
                HttpResponseMessage apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                if (apiResponse.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(apiContent);
                }
                else
                {
                    var errorResponse = new APIResponse
                    {
                        ErrorMessages = new List<string> { apiContent },
                        IsSuccess = false
                    };
                    return (T)Convert.ChangeType(errorResponse, typeof(T));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in SendAsync: {ex.Message}");
                var errorResponse = new APIResponse
                {
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };
                return (T)Convert.ChangeType(errorResponse, typeof(T));
            }
        }


    }

}
