namespace Demo.Report;

public class MonthlyProgress(Worklogs _worklogs)
{
    public List<Worklog> GetWorklogs(
        string? work = default
    )
    {
        return _worklogs.By(workName: work);
    }
}
