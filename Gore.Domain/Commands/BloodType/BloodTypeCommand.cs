using Gore.Domain.Core.Commands;

namespace Gore.Domain.Commands.BloodType
{
    public abstract class BloodTypeCommand : Command
    {
        public int BloodTypeId { get; protected set; }
        public string BloodTypeDescription { get; protected set; }
    }
}
