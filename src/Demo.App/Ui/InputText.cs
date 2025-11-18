using Baked.Ui;

namespace Demo.Ui;

public record InputText(string Name, string Placeholder)
    : IComponentSchema
{
    public string Name { get; set; } = Name;
    public string Placeholder { get; set; } = Placeholder;
}
