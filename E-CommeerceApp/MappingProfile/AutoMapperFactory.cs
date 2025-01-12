using AutoMapper;

namespace E_CommeerceApp.MappingProfile
{
    public class AutoMapperFactory
    {
        public static IMapper CreateMapper()
        {
            return new MapperConfiguration(cgf =>
            {
                cgf.AddProfile<DtosProfile>();
            }
            ).CreateMapper();
        }
    }
}
