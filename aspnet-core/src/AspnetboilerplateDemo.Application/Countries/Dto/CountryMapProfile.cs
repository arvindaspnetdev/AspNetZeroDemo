using AutoMapper;
 
namespace AspnetboilerplateDemo.Countries.Dto
{
    public class CountryMapProfile : Profile
    {
        public CountryMapProfile()
        {
            CreateMap<CountryDto, Country>();
            CreateMap<Country,CountryDto>();

            CreateMap<CreateCountryDto, Country>();
            CreateMap<Country, CountryListDto>();
            CreateMap<Country, CountryEditDto>();

        }
    }
}
