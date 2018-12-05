using Gore.Domain.Validations.Doctor;

namespace Gore.Domain.Commands.Doctor
{
    public class RemoveDoctorCommand : DoctorCommand
    {
        public RemoveDoctorCommand(int id)
        {
            DoctorId = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveDoctorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
