using EF_Api.DB.Interface;
using EF_Api.DB.models;

namespace EF_Api.DB.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly bookStoresDBContext _context;
        public IPublisherRepository Publisher { get; }
        public UnitOfWork(bookStoresDBContext context,IPublisherRepository publisher)
        {
            this.Publisher = publisher;
            this._context = context;
        }        

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
