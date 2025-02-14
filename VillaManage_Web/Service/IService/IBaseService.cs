using VillaManage_Web.Model;

namespace VillaManage_Web.Service.IService
{
    public interface IBaseService
    {

        APIResponse responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apIRequest);
    }
}
