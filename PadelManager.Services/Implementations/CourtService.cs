#region

using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;
using PadelManager.Services.Common;
using PadelManager.Services.Interfaces;

#endregion

namespace PadelManager.Services.Implementations
{
    public class CourtService : BaseService<Court>, ICourtService
    {
        public CourtService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}