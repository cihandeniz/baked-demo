using Baked.Theme;
using Baked.Ui;

namespace Baked;

public static class CustomThemeExtensions
{
    public static CustomThemeFeature Custom(this ThemeConfigurator _) =>
        new(
        [
            r => r.Index() with { Page = p => p.Described(d => d.Menu()) },
            r => r.Root("/league-nights/new", "New League Night", "pi pi-arrow-right") with
            {
                Page = p => p.Generated(d => d.Method<LeagueNight, FormPage>(nameof(LeagueNight.With))),
                Description = "Create a new league night"
            },
            r => r.RootDynamic("/league-nights/[id]", "League Night") with
            {
                Page = p => p.Generated(d => d.Type<LeagueNight, SimplePage>()),
                Description = "Display the league night details"
            }
        ]);
}
