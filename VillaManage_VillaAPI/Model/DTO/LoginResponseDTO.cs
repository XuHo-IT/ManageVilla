using VillaManage_Web.Model;

namespace VillaManage_VillaAPI.Model.DTO
{
    public class LoginResponseDTO
    {
        public UserDTO User { get; set; }
        public string Token { get; set; }
    }
}
