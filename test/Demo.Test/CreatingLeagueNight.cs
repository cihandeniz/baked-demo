namespace Demo.Test;

public class CreatingLeagueNight : DemoSpec
{
    LeagueNight NewLeagueNight(
        DateTime? date = default
    )
    {
        date ??= GiveMe.ADateTime();

        var newLeagueNight = GiveMe.The<Func<LeagueNight>>();

        return newLeagueNight().With(
            date: date.Value
        );
    }

    // LaneMoneySlip
    // 8 Lanes
    // one slip per lane per LeagueNight

    [Test]
    public void A_league_night_is_inserted_when_it_is_created()
    {
        var leagueNight = NewLeagueNight();

        leagueNight.ShouldBeInserted();
    }

    [Test]
    public void A_league_night_is_created_with_the_given_date()
    {
        var leagueNight = NewLeagueNight(date: new(2026, 01, 07));

        leagueNight.Date.ShouldBe(new(2026, 01, 07));
    }

    [Test]
    public void When_a_league_night_is_created__it_creates_8_lanes_by_default()
    {
        var leagueNight = NewLeagueNight();

        leagueNight.GetLaneMoneySlips().Count.ShouldBe(8);
    }

    [Test]
    public void Lane_number_starts_with_1()
    {
        var leagueNight = NewLeagueNight();

        var slips = leagueNight.GetLaneMoneySlips();
        slips[0].LaneNumber.ShouldBe(1);
        slips[^1].LaneNumber.ShouldBe(8);
    }
}
