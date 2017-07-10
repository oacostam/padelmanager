using System.ComponentModel.DataAnnotations;

namespace PadelManager.Core.Common
{
    public interface IEntity
    {
        int Id { get; set; }

        bool IsActive { get; set; }
    }
}