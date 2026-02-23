using System.Threading.Tasks;
using MusicLyricApp.Models;
using MusicLyricApp.ViewModels;

namespace MusicLyricApp.Core.Service;

public interface IStorageService
{
    void SetSearchService(ISearchService searchService);
    
    SettingBean ReadAppConfig();

    void SaveConfig(SettingBean settingBean);

    Task<string> SaveResult(SearchResultViewModel searchResult, SettingBean settingBean, IWindowProvider windowProvider);

    string SaveSongLink(SearchResultViewModel searchResult, SettingBean settingBean, IWindowProvider windowProvider);

    string SaveSongPic(SearchResultViewModel searchResult, SettingBean settingBean, IWindowProvider windowProvider);

    Task<string> DownloadSongLink(SearchResultViewModel searchResult, SettingBean settingBean, IWindowProvider windowProvider);

    Task<string> DownloadSongPic(SearchResultViewModel searchResult, SettingBean settingBean, IWindowProvider windowProvider);
}
