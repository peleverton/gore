using Gore.Domain.Interfaces;
using Gore.Domain.Models;
using Gore.Infra.Data.Context;

namespace Gore.Infra.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(GoreContext context) : base(context)
        {
        }
    }
}
