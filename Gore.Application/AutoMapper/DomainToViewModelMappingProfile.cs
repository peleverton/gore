using AutoMapper;
using Gore.Application.ViewModels;
using Gore.Domain.Models;

namespace Gore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<BloodType, BloodTypeViewModel>();
            CreateMap<Person, PersonViewModel>();//.ForMember(p => p.Address, c => c.MapFrom(c => c.Address));
            CreateMap<Address, AddressViewModel>();
            CreateMap<Doctor, DoctorViewModel>();
        }
    }
}
