namespace Demo.Test;

public class SubmittingANewWorklog : DemoSpec
{
    Worklog NewWorklog(
        DateTime? beginning = default,
        DateTime? ending = default
    )
    {
        beginning ??= GiveMe.ADateTime();
        ending ??= GiveMe.ADateTime();

        var newWorklog = GiveMe.The<Func<Worklog>>();

        return newWorklog().With(
            beginning: beginning.Value,
            ending: ending.Value
        );
    }

    [Test]
    public void It_has_a_log_text() => this.ShouldFail();

    [Test]
    public void It_is_associated_to_a_work() => this.ShouldFail();

    [Test]
    public void It_has_a_contributor() => this.ShouldFail();

    [Test]
    public void It_has_a_beginning_and_ending()
    {
        var actual = NewWorklog(
            beginning: new(2025, 06, 30, 21, 30, 00),
            ending: new(2025, 06, 30, 22, 30, 00)
        );

        actual.Beginning.ShouldBe(new(2025, 06, 30, 21, 30, 00));
        actual.Ending.ShouldBe(new(2025, 06, 30, 22, 30, 00));
    }

    [Test]
    public void Duration_is_calculated_using_beginning_and_ending() => this.ShouldFail();

    [Test]
    public void Duration_cant_be_more_than_eight_hours() => this.ShouldFail();

    [Test]
    public void Ending_should_be_after_beginning() => this.ShouldFail();

    [Test]
    public void Seconds_are_ignored() => this.ShouldFail();

    [Test]
    public void Minutes_are_rounded_to_nearest_quarter_of_the_hour() => this.ShouldFail();
}
