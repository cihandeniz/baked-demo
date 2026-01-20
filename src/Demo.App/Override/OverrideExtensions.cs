using Baked.Architecture;

namespace Baked;

public static class OverrideExtensions
{
    public static void AddOverrides(this List<IFeature> features)
    {
        features.Add(new Demo.Override.Ui.LeageNightUiOverrideFeature());
    }
}
