using AutoMapper;
using Gore.Application.ViewModels;
using Gore.Domain.Commands.Adress;
using Gore.Domain.Commands.BloodType;
using Gore.Domain.Commands.Doctor;
using Gore.Domain.Commands.Person;

namespace Gore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BloodTypeViewModel, RegisterNewBloodTypeCommand>()
                .ConstructUsing(c => new RegisterNewBloodTypeCommand(c.BloodTypeDescription));
            CreateMap<BloodTypeViewModel, UpdateBloodTypeCommand>()
                .ConstructUsing(c => new UpdateBloodTypeCommand(c.BloodTypeId, c.BloodTypeDescription));

            CreateMap<PersonViewModel, RegisterNewPersonCommand>()
                .ConvertUsing(c => new RegisterNewPersonCommand(c.FirstName, c.LastName, c.CPF, c.Email, c.DateOfBirth, c.Phone, c.Address, c.Gender, c.IsActive, c.BloodType.BloodTypeId));
            CreateMap<PersonViewModel, UpdatePersonCommand>()
                .ConvertUsing(c => new UpdatePersonCommand(c.PersonId, c.FirstName, c.LastName, c.CPF, c.Email, c.DateOfBirth, c.Phone, c.Address, c.Gender, c.IsActive, c.BloodType.BloodTypeId));

            CreateMap<AddressViewModel, RegisterNewAdressCommand>()
                .ConvertUsing(c => new RegisterNewAdressCommand(c.Street, c.Number, c.Cep, c.Complement, c.City, c.State));
            CreateMap<AddressViewModel, UpdateAdressCommand>()
                .ConvertUsing(c => new UpdateAdressCommand(c.AddressId, c.Street, c.Number, c.Cep, c.Complement, c.City, c.State));

            CreateMap<DoctorViewModel, RegisterNewDoctorCommand>()
                .ConvertUsing(c => new RegisterNewDoctorCommand(c.DoctorId, c.CRM, c.Person));
            CreateMap<DoctorViewModel, UpdateDoctorCommand>()
                .ConvertUsing(c => new UpdateDoctorCommand(c.DoctorId));

        }
    }
}
