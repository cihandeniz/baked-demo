using Baked.Orm;

namespace Demo;

/// <summary>
/// Represents a single focused work log about a work by a contributor.
/// </summary>
public class Worklog(IEntityContext<Worklog> _context)
{
    /// <summary>
    /// Id of the record
    /// </summary>
    public Guid Id { get; private set; } = default!;
    public DateTime Beginning { get; private set; } = default!;
    public DateTime Ending { get; private set; } = default!;
    public string Text { get; private set; } = default!;
    public Work Work { get; private set; } = default!;
    public Contributor Contributor { get; private set; } = default!;

    public TimeSpan Duration => Ending - Beginning;

    /// <summary>
    /// Submits a new worklog
    /// </summary>
    /// <param name="beginning">Beginning date and time of the work</param>
    /// <param name="ending">Ending date and time of the work</param>
    /// <param name="text">Short description of what work has been done</param>
    /// <param name="work">Related work</param>
    /// <param name="contributor">Person who has done this contribution</param>
    public Worklog With(DateTime beginning, DateTime ending, string text, Work work, Contributor contributor)
    {
        if (beginning >= ending) { throw new InvalidDurationException(beginning, ending); }

        Beginning = beginning;
        Ending = ending;
        Text = text;
        Work = work;
        Contributor = contributor;

        _context.Insert(this);

        return this;
    }
}

public class Worklogs(IQueryContext<Worklog> _context)
{
    internal List<Worklog> By(
        string? workName = default
    ) => _context.By(
        whereIf: [(workName is not null, w => w.Work.Name.StartsWith(workName ?? string.Empty))]
    );

    internal List<Worklog> ByWork(Work work) =>
        _context.By(w => w.Work == work);
}
