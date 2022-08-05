using EF_Api.DB.Interface;
using EF_Api.DB.models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EF_Api.DB.Repository
{
    public class PublisherRepository : BaseRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(bookStoresDBContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Publisher>> GetAllDetails()
        {
            return await context.Publisher
                 .Include(p => p.Book).ToListAsync();               
        }
    }
}
