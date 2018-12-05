using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using Gore.Infra.Data.Context;

namespace Gore.Infra.Data.Repository
{
    public class AdressRepository : Repository<Address>, IAdressRepository
    {
        public AdressRepository(GoreContext context) : base(context)
        {
        }
    }
}
