using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using Gore.Infra.Data.Context;

namespace Gore.Infra.Data.Repository
{
    public class BloodTypeRepository : Repository<BloodType>, IBloodTypeRepository
    {
        public BloodTypeRepository(GoreContext context) : base(context)
        {
        }
    }
}
