using Baked.Orm;

namespace Demo;

public class Contributor(IEntityContext<Contributor> _context)
{
    public Guid Id { get; protected set; } = default!;
    public string Name { get; protected set; } = default!;

    public Contributor With(string name)
    {
        _context.Insert(this);

        Name = name;

        return this;
    }

    public void Delete() =>
        _context.Delete(this);
}

public class Contributors(IQueryContext<Contributor> _context)
{
    internal List<Contributor> By() =>
        _context.By(_ => true);
}
