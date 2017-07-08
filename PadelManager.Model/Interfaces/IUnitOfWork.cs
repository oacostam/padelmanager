using System;

namespace PadelManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}