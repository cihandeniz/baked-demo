using Baked.Orm;

namespace Demo;

public class Work(IEntityContext<Work> _context, Worklogs _worklogs)
{
    public Guid Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;

    public Work With(string name)
    {
        Name = name;

        _context.Insert(this);

        return this;
    }

    public void Delete() =>
        _context.Delete(this);

    public List<Worklog> GetWorklogs() =>
        _worklogs.ByWork(this);
}

public class Works(IQueryContext<Work> _context)
{
    internal List<Work> By() =>
        _context.By(_ => true);
}
