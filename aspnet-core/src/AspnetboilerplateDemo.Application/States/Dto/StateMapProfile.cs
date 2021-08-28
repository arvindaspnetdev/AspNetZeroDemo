using AutoMapper;
 
namespace AspnetboilerplateDemo.States.Dto
{
    public class StateMapProfile : Profile
    {
        public StateMapProfile()
        {
            CreateMap<StateDto, State>();
            CreateMap<State, StateDto>().ForMember(x => x.CountryName,
                opt => opt.MapFrom(x => x.Countries.CountryName));

            CreateMap<CreateStateDto, State>();
            CreateMap<State, StateListDto>();
            CreateMap<State, StateEditDto>();
            CreateMap<State, GetStateForEditOutput>();
        }
    }
}
