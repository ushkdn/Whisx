namespace Whisx.Shared.Base.Entities;

public abstract class EntityBase : Entity, IEntityBase
{
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
}