namespace PadelManager.Core.Common
{
    public abstract class Entity : IEntity
    {
        public virtual int Id { get; set; }
        public bool IsActive { get; set; }
    }
}