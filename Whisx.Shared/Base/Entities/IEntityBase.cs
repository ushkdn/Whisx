namespace Whisx.Shared.Base.Entities;

public interface IEntityBase : IEntity
{
    public DateTime DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }
}