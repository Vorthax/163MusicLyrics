using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MusicLyricApp.Views;

public partial class FormatConvertView : UserControl
{
    public FormatConvertView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
