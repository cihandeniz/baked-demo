using Baked.Orm;

namespace Demo;

public class Work(IEntityContext<Work> _context)
{
    protected Work() : this(default!) { }

    public virtual Guid Id { get; protected set; } = default!;
    public virtual string Name { get; protected set; } = default!;

    public virtual Work With(string name)
    {
        Name = name;

        _context.Insert(this);

        return this;
    }
}

public class Works(IQueryContext<Work> _context)
{
    internal List<Work> By() =>
        _context.By(_ => true);
}
