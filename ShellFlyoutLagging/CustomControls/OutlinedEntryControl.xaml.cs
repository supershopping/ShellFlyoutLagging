namespace ShellFlyoutLagging.CustomControls;

public partial class OutlinedEntryControl : Grid
{
    public OutlinedEntryControl()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty IsEntryEnabledProperty = BindableProperty.Create(
    propertyName: nameof(IsEntryEnabled),
    returnType: typeof(bool),
    declaringType: typeof(OutlinedEntryControl),
    defaultValue: true,
    defaultBindingMode: BindingMode.TwoWay);


    public bool IsEntryEnabled
    {
        get => (bool)GetValue(IsEntryEnabledProperty);
        set => SetValue(IsEntryEnabledProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: nameof(Text),
        returnType: typeof(string),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.TwoWay);


    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
        propertyName: nameof(Placeholder),
        returnType: typeof(string),
        declaringType: typeof(OutlinedEntryControl),
        defaultValue: null,
        defaultBindingMode: BindingMode.OneWay);


    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    private void txtEntry_Focused(object sender, FocusEventArgs e)
    {

        lblPlaceholder.FontSize = 12;
        lblPlaceholder.TranslateTo(0, -26, 80, easing: Easing.Linear);

    }

    private void txtEntry_Unfocused(object sender, FocusEventArgs e)
    {

        if (!string.IsNullOrWhiteSpace(Text))
        {
            lblPlaceholder.FontSize = 12;
            lblPlaceholder.TranslateTo(0, -26, 80, easing: Easing.Linear);
        }
        else
        {
            lblPlaceholder.FontSize = 16;
            lblPlaceholder.TranslateTo(0, 0, 80, easing: Easing.Linear);
        }

    }

    private void txtEntry_Completed(object sender, EventArgs e)
    {
        IsEntryEnabled= false;
        IsEntryEnabled = true;

    }
}