using Gore.Domain.Validations.Doctor;

namespace Gore.Domain.Commands.Doctor
{
    public class RegisterNewDoctorCommand : DoctorCommand
    {
        public RegisterNewDoctorCommand(int doctorId, string crm, Gore.Domain.Models.Person person)
        {
            DoctorId = doctorId;
            CRM = crm;
            Person = person;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewDoctorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
