using Gore.Domain.Commands.Doctor;

namespace Gore.Domain.Validations.Doctor
{
    public  class UpdateDoctorCommandValidation : DoctorValidation<UpdateDoctorCommand>
    {
        public UpdateDoctorCommandValidation()
        {
            ValidateId();
            ValidateCrm();
        }
    }
}
