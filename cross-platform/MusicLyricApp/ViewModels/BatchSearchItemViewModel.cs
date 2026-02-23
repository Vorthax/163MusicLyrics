using CommunityToolkit.Mvvm.ComponentModel;

namespace MusicLyricApp.ViewModels;

public partial class BatchSearchItemViewModel : ObservableObject
{
    [ObservableProperty] private bool _isSelected;
    [ObservableProperty] private string _songSource = "";
    [ObservableProperty] private string _songId = "";
    [ObservableProperty] private string _songName = "";
    [ObservableProperty] private string _singer = "";
    [ObservableProperty] private string _album = "";
    [ObservableProperty] private string _status = "";
    [ObservableProperty] private string _error = "";
    [ObservableProperty] private int _progress;
}
