using Baked.Orm;

namespace Demo;

public class Contributor(IEntityContext<Contributor> _context)
{
    protected Contributor() : this(default!) { }

    public virtual Guid Id { get; protected set; } = default!;
    public virtual string Name { get; protected set; } = default!;

    public virtual Contributor With(string name)
    {
        _context.Insert(this);

        Name = name;

        return this;
    }
}

public class Contributors(IQueryContext<Contributor> _context)
{
    internal List<Contributor> By() =>
        _context.By(_ => true);
}
