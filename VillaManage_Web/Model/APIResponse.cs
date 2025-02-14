using System.Net;

namespace VillaManage_Web.Model
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessagess { get; set; }
        public object Result { get; set; }
    }
}
