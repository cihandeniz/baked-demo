using Baked.Architecture;
using Baked.Orm;
using Baked.RestApi;
using Baked.Theme;
using Baked.Theme.Default;
using Baked.Ui;
using Demo.Ui;
using Humanizer;

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
                where: cc => cc.Path.EndsWith(nameof(DataTable.Columns), "*", nameof(DataTable.Column.Component), nameof(Conditional.Fallback)),
                component: c => B.Text()
            );

            builder.Conventions.AddPropertyComponent(
                when: c => c.Property.PropertyType.TryGetMetadata(out var metadata) && metadata.Has<EntityAttribute>(),
                where: cc => cc.Path.EndsWith(nameof(DataTable.Columns), "*", nameof(DataTable.Column.Component), nameof(Conditional.Fallback)),
                component: c => D.TextProp("id")
            );
            builder.Conventions.AddPropertyComponentConfiguration<TextProp>(
                when: c => c.Property.PropertyType.TryGetMembers(out var members) && members.Properties.Contains("Name"),
                component: (tp, c) => tp.Schema.Prop = c.Property.PropertyType.GetMembers().Properties["Name"].Get<DataAttribute>().Prop
            );

            builder.Conventions.RemoveMethodAttribute<DescriptorBuilderAttribute<DataTable.Export>>(c => true,
                order: RestApiLayer.MaxConventionOrder * 2
            );

            builder.Conventions.AddParameterComponent(
                when: c => c.Parameter.ParameterType.Is<string>(),
                component: c => D.InputText(c.Parameter.Name, c.Parameter.Name.Titleize())
            );
        });

        configurator.ConfigureComponentExports(exports =>
        {
            exports.AddFromExtensions(typeof(D));
        });
    }
}
