using Baked.Orm;

namespace Demo;

/// <summary>
/// Represents a single focused work log about a work by a contributor.
/// </summary>
public class Worklog(IEntityContext<Worklog> _context)
{
    protected Worklog() : this(default!) { }

    /// <summary>
    /// Id of the record
    /// </summary>
    public virtual Guid Id { get; protected set; } = default!;
    public virtual DateTime Beginning { get; protected set; } = default!;
    public virtual DateTime Ending { get; protected set; } = default!;
    public virtual string Text { get; protected set; } = default!;
    public virtual Work Work { get; protected set; } = default!;
    public virtual Contributor Contributor { get; protected set; } = default!;

    public virtual TimeSpan Duration => Ending - Beginning;

    /// <summary>
    /// Submits a new worklog
    /// </summary>
    /// <param name="beginning">Beginning date and time of the work</param>
    /// <param name="ending">Ending date and time of the work</param>
    /// <param name="text">Short description of what work has been done</param>
    /// <param name="work">Related work</param>
    /// <param name="contributor">Person who has done this contribution</param>
    public virtual Worklog With(DateTime beginning, DateTime ending, string text, Work work, Contributor contributor)
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
    internal List<Worklog> By() =>
        _context.By(_ => true);
}
