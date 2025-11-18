namespace Demo.Test;

public static class Extensions
{
    public static Work AWork(this Stubber giveMe,
        string? name = default
    )
    {
        name ??= "test work";

        return giveMe.A<Work>().With(name);
    }

    public static Contributor AContributor(this Stubber giveMe,
        string? name = default
    )
    {
        name ??= giveMe.AString();

        return giveMe
            .A<Contributor>()
            .With(
                name: name
             );
    }
}
