using Baked.Ui;

namespace Demo.Ui;

public static class Components
{
    public static ComponentDescriptor<InputText> InputText(string name, string placeholder,
        Action<InputText>? options = default
    ) => new(options.Apply(new(name, placeholder)));

    public static ComponentDescriptor<TextProp> TextProp(string prop,
        Action<TextProp>? options = default
    ) => new(options.Apply(new(prop)));
}
