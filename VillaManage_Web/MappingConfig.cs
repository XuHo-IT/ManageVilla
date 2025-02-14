using AutoMapper;
using VillaManage_Web.Model.DTO;

namespace VillaManage_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<VillaDTO, VillaCreateDTO>();
            CreateMap<VillaDTO, VillaUpdateDTO>();
        
            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}
