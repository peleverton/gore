using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using Gore.Infra.Data.Context;

namespace Gore.Infra.Data.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(GoreContext context) : base(context)
        {
        }
        
    }
}
