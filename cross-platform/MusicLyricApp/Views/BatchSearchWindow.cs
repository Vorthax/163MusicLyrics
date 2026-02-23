using System.Collections.Generic;
using Avalonia.Controls;
using MusicLyricApp.Models;
using MusicLyricApp.ViewModels;

namespace MusicLyricApp.Views;

public class BatchSearchWindow : Window
{
    private readonly BatchSearchViewModel _viewModel;

    public BatchSearchWindow(BatchSearchViewModel viewModel)
    {
        Title = "下载管理";
        Width = 1100;
        Height = 720;

        _viewModel = viewModel;
        DataContext = _viewModel;
        Content = new BatchSearchView();
        Icon = Constants.GetIcon("search-result");
    }

    public void AddResults(Dictionary<string, ResultVo<SaveVo>> resDict, List<InputSongId> inputSongIds, string? inputText = null)
    {
        _viewModel.AddSearchResults(resDict, inputSongIds, inputText);
    }
}
