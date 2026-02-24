using Avalonia.Controls;
using MusicLyricApp.Models;
using MusicLyricApp.ViewModels;

namespace MusicLyricApp.Views;

public class FormatConvertWindow : Window
{
    public FormatConvertWindow(SettingBean settingBean)
    {
        Title = "格式转换";
        Width = 980;
        Height = 640;
        MinWidth = 860;
        MinHeight = 520;

        DataContext = new FormatConvertViewModel(settingBean);
        Content = new FormatConvertView();
        Icon = Constants.GetIcon("settings");
    }
}

