using Gore.Domain.Commands.Doctor;

namespace Gore.Domain.Validations.Doctor
{
    public class RemoveDoctorCommandValidation : DoctorValidation<RemoveDoctorCommand>
    {
        public RemoveDoctorCommandValidation()
        {
            ValidateId();
        }
    }
}
