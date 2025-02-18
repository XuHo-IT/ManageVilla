using AutoMapper;
using VillaManage_VillaAPI.Model;
using VillaManage_VillaAPI.Model.DTO;

namespace VillaManage_VillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Villa, VillaDTO>();
            CreateMap<VillaDTO, Villa>();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDTO>();
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberDTO>();
            CreateMap<VillaNumber, VillaDTO>();
            CreateMap<VillaNumber, List<VillaDTO>>();
            CreateMap<ApplicationUser, UserDTO>();


        }
    }
}
