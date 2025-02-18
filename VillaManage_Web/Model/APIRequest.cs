using static VillaManage.SD;

namespace VillaManage_Web.Model
{
    public class APIRequest
    {
        public ApiType APIType { get; set; }
        public string Url { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
