using Baked.Orm;

namespace Demo;

public class Worklog(IEntityContext<Worklog> _context)
{
    protected Worklog() : this(default!) { }

    public virtual Guid Id { get; protected set; } = default!;
    public virtual DateTime Beginning { get; protected set; } = default!;
    public virtual DateTime Ending { get; protected set; } = default!;

    public virtual Worklog With(DateTime beginning, DateTime ending)
    {
        Beginning = beginning;
        Ending = ending;

        _context.Insert(this);

        return this;
    }
}

public class Worklogs(IQueryContext<Worklog> _context)
{
    public List<Worklog> By() =>
        _context.By(_ => true);
}
