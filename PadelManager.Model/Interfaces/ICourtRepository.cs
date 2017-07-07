using System.Data.Entity;
using PadelManager.Core.Models;

namespace PadelManager.Core.Interfaces
{
    public interface ICourtRepository : IUnitOfWork
    {
        IDbSet<Court> Courts { get; set; }
    }
}