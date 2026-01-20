namespace Demo.Test;

public static class Extensions
{
    public static LeagueNight ALeagueNight(this Stubber giveMe,
        DateTime? date = default
    )
    {
        date ??= giveMe.ADateTime();

        return giveMe
            .A<LeagueNight>()
            .With(
                date: date.Value
             );
    }
}
