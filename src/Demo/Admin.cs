namespace Demo;

public class Admin(
    SeedData _seedData,
    Func<Work> _newWork,
    Works _works,
    Func<Contributor> _newContributor,
    Contributors _contributors
)
{
    public void SeedData() =>
        _seedData.Execute();

    public Work AddWork(string name) =>
        _newWork().With(name);

    public List<Work> GetWorks() =>
        _works.By();

    public Contributor AddContributor(string name) =>
        _newContributor().With(name);

    public List<Contributor> GetContributors() =>
        _contributors.By();
}
