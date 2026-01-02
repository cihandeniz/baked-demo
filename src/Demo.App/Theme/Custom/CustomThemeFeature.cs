using Baked.Architecture;
using Baked.Theme;
using Baked.Theme.Default;
using Baked.Ui;

using D = Demo.Ui.Components;

using Route = Baked.Theme.Route;

namespace Demo;

public class CustomThemeFeature(IEnumerable<Func<Router, Route>> routes)
    : DefaultThemeFeature(routes.Select(r => r(new())))
{
    public override void Configure(LayerConfigurator configurator)
    {
        base.Configure(configurator);

        configurator.ConfigureDomainModelBuilder(builder =>
        {
            builder.Conventions.RemoveMethodAttribute<DescriptorBuilderAttribute<DataTable.Export>>(c => true,
                order: int.MaxValue,
                requiresIndex: false
            );
        });

        configurator.ConfigureComponentExports(exports =>
        {
            exports.AddFromExtensions(typeof(D));
        });
    }
}
