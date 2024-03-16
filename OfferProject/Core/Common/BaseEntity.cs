namespace Core.Common;

public abstract class BaseEntity<T> : IEntity<T>
    where T : struct
{
    public T Id { get; set; }
}