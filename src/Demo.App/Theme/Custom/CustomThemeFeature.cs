using Baked.Architecture;
using Baked.Theme;
using Baked.Theme.Default;

using Route = Baked.Theme.Route;

public class CustomThemeFeature(IEnumerable<Func<Router, Route>> routes)
    : DefaultThemeFeature(routes.Select(r => r(new())))
{
    public override void Configure(LayerConfigurator configurator)
    {
        base.Configure(configurator);
    }
}
