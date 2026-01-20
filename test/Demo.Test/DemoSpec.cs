namespace Demo.Test;

public class DemoSpec : MonolithSpec
{
    static DemoSpec() =>
        Init(
            business: c => c.DomainAssemblies(typeof(LeagueNight).Assembly)
        );
}
