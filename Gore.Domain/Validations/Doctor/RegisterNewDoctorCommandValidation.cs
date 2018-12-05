using Gore.Domain.Commands.Doctor;

namespace Gore.Domain.Validations.Doctor
{
    public class RegisterNewDoctorCommandValidation : DoctorValidation<RegisterNewDoctorCommand>
    {
        public RegisterNewDoctorCommandValidation()
        {
            ValidateCrm();
        }
    }
}
