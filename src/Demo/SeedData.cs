namespace Demo;

public class SeedData(Func<Contributor> _newContributor, Func<Worklog> _newWorklog, Func<Work> _newWork)
{
    public void Execute()
    {
        var contributor = _newContributor().With("Cihan");
        var work = _newWork().With("Prepare a demo");

        _newWorklog().With(new(2025, 10, 1, 10, 0, 0), new(2025, 10, 1, 11, 0, 0), "plan and init pr", work, contributor);
        _newWorklog().With(new(2025, 10, 1, 11, 30, 0), new(2025, 10, 1, 12, 0, 0), "prepare cases", work, contributor);
        _newWorklog().With(new(2025, 10, 1, 12, 30, 0), new(2025, 10, 1, 14, 0, 0), "implement and deploy", work, contributor);
        _newWorklog().With(new(2025, 10, 1, 14, 30, 0), new(2025, 10, 1, 16, 0, 0), "self-review and merge", work, contributor);
    }
}
