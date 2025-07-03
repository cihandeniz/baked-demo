namespace Demo.Test;

public class AddingAContributor : DemoSpec
{
    Contributor NewContributor(
        string? name = default
    )
    {
        name ??= GiveMe.AString();

        var newContributor = GiveMe.The<Func<Contributor>>();

        return newContributor().With(
            name: name
        );
    }

    [Test]
    public void Contributor_is_persisted_in_db()
    {
        var actual = NewContributor();

        actual.ShouldBeInserted();
    }

    [Test]
    public void It_has_a_name()
    {
        var actual = NewContributor(name: "John Doe");

        actual.Name.ShouldBe("John Doe");
    }
}
