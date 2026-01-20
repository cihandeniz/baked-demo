using Baked.Orm;

namespace Demo;

public class LeagueNight(IEntityContext<LeagueNight> _context)
{
    public Guid Id { get; protected set; } = default!;
    public DateTime Date { get; protected set; } = default!;

    public LeagueNight With(DateTime date)
    {
        Date = date;

        _context.Insert(this);

        return this;
    }

    public List<LaneMoneySlip> GetLaneMoneySlips()
    {
        return
        [
            .. Enumerable
            .Range(1, 8)
            .Select(i => new LaneMoneySlip() { LaneNumber = i })
        ];
    }
}

public class LeagueNights(IQueryContext<LeagueNight> _context)
{
    internal List<LeagueNight> By() =>
        _context.By(_ => true);
}
