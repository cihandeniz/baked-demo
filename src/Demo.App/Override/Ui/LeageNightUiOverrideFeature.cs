using Baked.Architecture;
using Baked.Theme.Default;

using B = Baked.Ui.Components;

namespace Demo.Override.Ui;

public class LeageNightUiOverrideFeature : IFeature
{
    public void Configure(LayerConfigurator configurator)
    {
        configurator.ConfigureDomainModelBuilder(builder =>
        {
            builder.Conventions.AddEntityRemoteData<LeagueNight>();
            builder.Conventions.AddSingleById<LeagueNights>();

            builder.Conventions.SetPropertyAttribute(
                when: c => c.Type.Is<LeagueNight>() && c.Property.Name == nameof(LeagueNight.Date),
                attribute: () => new LabelAttribute()
            );

            builder.Conventions.AddParameterComponent(
                when: c => c.Type.Is<LeagueNight>() && c.Method.Name == nameof(LeagueNight.With) && c.Parameter.Name == "date",
                where: cc => cc.Path.EndsWith("page", "league-night", "with", "inputs", "date", "date", "component"),
                component: () => B.InputText("Date")
            );
        });
    }
}
