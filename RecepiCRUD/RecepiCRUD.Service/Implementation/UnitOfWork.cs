using RecepiCRUD.Entity;
using RecepiCRUD.Service.Interfaces;

namespace RecepiCRUD.Service.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRecepiService RecepiService { get; }
        private readonly RecepiContext _recepiContext;

        public UnitOfWork(RecepiContext recepiContext)
        {
            _recepiContext = recepiContext;
            RecepiService = new RecepiService(recepiContext);
        }

        public void Complete() => _recepiContext.SaveChangesAsync();
        public void Dispose() => _recepiContext.Dispose();
    }
}
