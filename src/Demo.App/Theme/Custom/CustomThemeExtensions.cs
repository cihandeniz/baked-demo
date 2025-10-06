using Baked.Theme;
using Demo.Report;

namespace Baked;

public static class CustomThemeExtensions
{
    public static CustomThemeFeature Custom(this ThemeConfigurator _) =>
        new(
        [
            r => r.Index() with { Page = p => p.Described(d => d.Menu()) },
            r => r.Root("/report/monthly-progress", "Monthly Progress", "pi pi-arrow-right") with
            {
                Page = p => p.Generated(d => d.From<MonthlyProgress>()),
                Description = "Shows current month's progress report"
            }
        ]);
}
