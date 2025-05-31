namespace Whisx.Shared.Base.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}