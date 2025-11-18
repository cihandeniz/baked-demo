using Baked.Ui;

namespace Demo.Ui;

public record TextProp(string Prop)
    : IComponentSchema
{
    public string Prop { get; set; } = Prop;
}
