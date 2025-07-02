namespace Demo.Test;

public class SubmittingANewWorklog : DemoSpec
{
    Worklog NewWorklog(
        DateTime? beginning = default,
        DateTime? ending = default,
        string? text = default,
        Work? work = default,
        Contributor? contributor = default
    )
    {
        beginning ??= GiveMe.ADateTime();
        ending ??= beginning.Value.AddMinutes(15);
        text ??= GiveMe.AString();
        work ??= GiveMe.AWork();
        contributor ??= GiveMe.AContributor();

        var newWorklog = GiveMe.The<Func<Worklog>>();

        return newWorklog().With(
            beginning: beginning.Value,
            ending: ending.Value,
            text: text,
            work: work,
            contributor: contributor
        );
    }

    [Test]
    public void It_has_a_log_text()
    {
        var actual = NewWorklog(text: "TEST TEXT");

        actual.Text.ShouldBe("TEST TEXT");
    }

    [Test]
    public void It_is_associated_to_a_work()
    {
        var work = GiveMe.AWork();

        var actual = NewWorklog(work: work);

        actual.Work.ShouldBe(work);
    }

    [Test]
    public void It_has_a_contributor()
    {
        var contributor = GiveMe.AContributor();

        var actual = NewWorklog(contributor: contributor);

        actual.Contributor.ShouldBe(contributor);
    }

    [Test]
    public void It_has_a_beginning_and_ending()
    {
        var beginning = new DateTime(2025, 06, 30, 21, 30, 00);
        var ending = new DateTime(2025, 06, 30, 22, 30, 00);

        var actual = NewWorklog(beginning: beginning, ending: ending);

        actual.Beginning.ShouldBe(beginning);
        actual.Ending.ShouldBe(ending);
    }

    [Test]
    public void Duration_is_calculated_using_beginning_and_ending()
    {
        var beginning = new DateTime(2025, 06, 30, 21, 30, 00);
        var ending = beginning.AddHours(2);

        var actual = NewWorklog(beginning: beginning, ending: ending);

        actual.Duration.ShouldBe(TimeSpan.FromHours(2));
    }

    [Test]
    [Ignore("not yet")]
    public void Duration_cant_be_more_than_eight_hours() => this.ShouldFail();

    [Test]
    public void Ending_should_be_after_beginning()
    {
        var beginning = new DateTime(2025, 06, 30, 21, 30, 00);
        var ending = beginning;

        var actual = () => NewWorklog(beginning: beginning, ending: ending);

        var exception = actual.ShouldThrow<InvalidDurationException>();
        exception.Message.ShouldContain($"{beginning}");
        exception.Message.ShouldContain($"{ending}");
        exception.ExtraData[nameof(beginning)].ShouldBe(beginning);
        exception.ExtraData[nameof(ending)].ShouldBe(ending);
    }

    [Test]
    [Ignore("not yet")]
    public void Seconds_are_ignored() => this.ShouldFail();

    [Test]
    [Ignore("not yet")]
    public void Minutes_are_rounded_to_nearest_quarter_of_the_hour() => this.ShouldFail();
}
