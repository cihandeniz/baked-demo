namespace Demo.Test;

public static class Extensions
{
    public static Work AWork(this Stubber giveMe) =>
        giveMe.A<Work>().With();

    public static Contributor AContributor(this Stubber giveMe) =>
        giveMe.A<Contributor>().With();
}
