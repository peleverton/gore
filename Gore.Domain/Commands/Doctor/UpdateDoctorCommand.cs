using Gore.Domain.Validations.Doctor;

namespace Gore.Domain.Commands.Doctor
{
    public class UpdateDoctorCommand : DoctorCommand
    {
        public UpdateDoctorCommand(int id)
        {
            DoctorId = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateDoctorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
