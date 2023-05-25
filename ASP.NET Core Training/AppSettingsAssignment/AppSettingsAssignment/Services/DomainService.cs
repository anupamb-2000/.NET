using AutoMapper;

namespace AppSettingsAssignment.Services
{
    public abstract class DomainService 
    {
        protected IMapper Mapper { get; }

        protected DomainService(IMapper mapper) : base()
        {
            Mapper = mapper;
        }
    }
}
