namespace Demo.Report;

public class MonthlyProgress(Worklogs _worklogs)
{
    public List<Worklog> GetWorklogs()
    {
        return _worklogs.By();
    }
}
