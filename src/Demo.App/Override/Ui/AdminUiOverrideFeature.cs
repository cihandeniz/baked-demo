using Baked.Architecture;
using Baked.Ui;
using Humanizer;

namespace Demo.Override.Ui;

public class AdminUiOverrideFeature : IFeature
{
    public void Configure(LayerConfigurator configurator)
    {
        configurator.ConfigureDomainModelBuilder(builder =>
        {
            builder.Conventions.AddMethodComponentConfiguration<DataPanel>(
                when: c => c.Type.Is<Admin>() && c.Method.Name == nameof(Admin.GetWorks),
                component: dp =>
                {
                    dp.Schema.Content.ReloadOn(nameof(Admin.AddWork).Kebaberize());
                    dp.Schema.Content.ReloadOn(nameof(Admin.SeedData).Kebaberize());
                }
            );
            builder.Conventions.AddMethodComponentConfiguration<DataPanel>(
                when: c => c.Type.Is<Admin>() && c.Method.Name == nameof(Admin.GetContributors),
                component: dp =>
                {
                    dp.Schema.Content.ReloadOn(nameof(Admin.AddContributor).Kebaberize());
                    dp.Schema.Content.ReloadOn(nameof(Admin.SeedData).Kebaberize());
                }
            );
        });
    }
}
