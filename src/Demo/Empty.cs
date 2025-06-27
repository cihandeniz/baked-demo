using Baked.Orm;

namespace Demo;

public class Empty(IEntityContext<Empty> _context)
{
    protected Empty() : this(default!) { }

    public virtual Guid Id { get; protected set; } = default!;

    public virtual Empty With()
    {
        _context.Insert(this);

        return this;
    }
}

public class Empties(IQueryContext<Empty> _context)
{
    public List<Empty> By() =>
        _context.By(_ => true);
}
