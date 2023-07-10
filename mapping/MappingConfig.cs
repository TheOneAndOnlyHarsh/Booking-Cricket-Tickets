using WebApp.Models;
using WebApp.Models.DTO;
using WebApp.Models.DTO;

namespace WebApp
{
    public class MappingConfig : AutoMapper.Profile
    {
        public  MappingConfig()
        {
            // these methods are used for mapping:
            ///we can use custom mappping as well using for
            CreateMap<UserDTO, UserCreateDTO>().ReverseMap();
            CreateMap<UserDTO, UserUpdateDTO>().ReverseMap();
            CreateMap<TicketDetailsDTO, TicketCreateDTO>().ReverseMap();
            CreateMap<TicketDetailsDTO, TicketUpdateDTO>().ReverseMap();








        }

    }
}
