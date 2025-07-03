namespace Demo.Test;

public static class Extensions
{
    public static Work AWork(this Stubber giveMe) =>
        giveMe.A<Work>().With();

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
