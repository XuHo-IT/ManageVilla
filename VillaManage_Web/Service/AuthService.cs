using VillaManage;
using VillaManage_Web.Model;
using VillaManage_Web.Model.DTO;
using VillaManage_Web.Service.IService;

namespace VillaManage_Web.Service
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
    private string villaUrl;

    public AuthService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
    {
        _clientFactory = clientFactory;
        villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
    }

        public Task<T> LoginAsync<T>(LoginRequestDTO obj)
        {
          return SendAsync<T>(new APIRequest()
            {
                APIType = SD.ApiType.POST,
                Data = obj,
                Url = villaUrl + "/api/v1/UserAuth/login"
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDTO obj)
        {
             return SendAsync<T>(new APIRequest()
            {
                APIType = SD.ApiType.POST,
                Data = obj,
                Url = villaUrl + "/api/v1/UserAuth/register"
             });
        }
    }
}
