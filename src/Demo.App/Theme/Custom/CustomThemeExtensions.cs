using Baked.Theme;
using Baked.Ui;
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
                Page = p => p.Generated(d => d.Type<MonthlyProgress, TabbedPage>()),
                Description = "Shows current month's progress report"
            },
            r => r.Root("/admin", "Admin", "pi pi-warehouse") with
            {
                Page = p => p.Generated(d => d.Type<Admin, SimplePage>()),
                Description = "Manage data"
            }
        ]);
}
