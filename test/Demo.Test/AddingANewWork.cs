namespace Demo.Test;

public class AddingANewWork : DemoSpec
{
    Work NewWork(
        string? name = default
    )
    {
        name ??= GiveMe.AString();

        var newWork = GiveMe.The<Func<Work>>();

        return newWork().With(name);
    }

    [Test]
    public void Work_is_persisted_in_db()
    {
        var actual = NewWork();

        actual.ShouldBeInserted();
    }
}
