using Baked.Architecture;
using Baked.Theme;
using Baked.Theme.Default;
using Baked.Ui;

using B = Baked.Ui.Components;
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
            builder.Conventions.AddPropertyComponent(
                when: c => c.Property.PropertyType.Is<DateTime>() || c.Property.PropertyType.Is<TimeSpan>(),
                component: c => B.Text()
            );

            builder.Conventions.RemoveMethodAttribute<DescriptorBuilderAttribute<DataTable.Export>>(c => true,
                order: int.MaxValue
            );
        });

        configurator.ConfigureComponentExports(exports =>
        {
            exports.AddFromExtensions(typeof(D));
        });
    }
}
