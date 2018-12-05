using Gore.Domain.Interfaces;
using Gore.Infra.Data.Context;
namespace Gore.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GoreContext _goreContext;

        public UnitOfWork(GoreContext goreContext)
        {
             _goreContext = goreContext; 
        }

        public bool Commit()
        {
            return _goreContext.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _goreContext.Dispose();
        }
    }
}
