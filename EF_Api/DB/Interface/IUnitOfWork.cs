using System;

namespace EF_Api.DB.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IPublisherRepository Publisher { get; }
        int Complete();
    }
}
