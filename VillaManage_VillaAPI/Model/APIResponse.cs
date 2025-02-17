using System.Net;

namespace VillaManage_VillaAPI.Model
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessagess = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessagess { get; set; }
        public object Result { get; set; }
    }
}
