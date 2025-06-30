namespace Demo.Test;

public class DemoSpec : ServiceSpec
{
    static DemoSpec() =>
        Init(
            business: c => c.DomainAssemblies(typeof(Worklog).Assembly)
        );
}
