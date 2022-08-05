using EF_Api.DB.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EF_Api.DB.Interface
{
    public interface IPublisherRepository:IBaseRepository<Publisher>
    {
        public Task<IEnumerable<Publisher>> GetAllDetails();
    }
}
