using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gore.Domain.Models
{
    public class BloodType //: Entity
    {

        public BloodType(int bloodTypeId, string bloodTypeDescription)
        {
            BloodTypeId = bloodTypeId;
            BloodTypeDescription = bloodTypeDescription;
        }

        public BloodType(string bloodTypeDescription)
        {
            BloodTypeDescription = bloodTypeDescription;
        }

        protected BloodType(){ }

        [BindNever]
        public int BloodTypeId { get; private set; }

        public string BloodTypeDescription { get; private set; }


    }
}
