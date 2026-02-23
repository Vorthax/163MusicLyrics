using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using MusicLyricApp.Core.Utils;
using MusicLyricApp.Models;

namespace MusicLyricApp.ViewModels;

public partial class SettingParamViewModel : ViewModelBase
{
    // 1. 毫秒截位规则
    public ObservableCollection<EnumDisplayHelper.EnumDisplayItem<DotTypeEnum>> DotTypes { get; } =
        EnumDisplayHelper.GetEnumDisplayCollection<DotTypeEnum>();
    
    [ObservableProperty]
    private EnumDisplayHelper.EnumDisplayItem<DotTypeEnum> _selectedDotTypeItem;

    public DotTypeEnum SelectedDotType => SelectedDotTypeItem?.Value ?? default;
    
    partial void OnSelectedDotTypeItemChanged(EnumDisplayHelper.EnumDisplayItem<DotTypeEnum>? value)
    {
        if (value != null) _settingBean.Config.DotType = value.Value;
    }
    
    // 2. 译文缺省规则
    public ObservableCollection<EnumDisplayHelper.EnumDisplayItem<TransLyricLostRuleEnum>> TransLyricLostRules { get; } =
        EnumDisplayHelper.GetEnumDisplayCollection<TransLyricLostRuleEnum>();
    
    [ObservableProperty]
    private EnumDisplayHelper.EnumDisplayItem<TransLyricLostRuleEnum> _selectedTransLyricLostRuleItem;

    public TransLyricLostRuleEnum SelectedTransLyricLostRule => SelectedTransLyricLostRuleItem?.Value ?? default;
    
    partial void OnSelectedTransLyricLostRuleItemChanged(EnumDisplayHelper.EnumDisplayItem<TransLyricLostRuleEnum>? value)
    {
        if (value != null) _settingBean.Config.TransConfig.LostRule = value.Value;
    }
    
    // 3. 中文处理策略
    public ObservableCollection<EnumDisplayHelper.EnumDisplayItem<ChineseProcessRuleEnum>> ChineseProcessRules { get; } =
        EnumDisplayHelper.GetEnumDisplayCollection<ChineseProcessRuleEnum>();
    
    [ObservableProperty]
    private EnumDisplayHelper.EnumDisplayItem<ChineseProcessRuleEnum> _selectedChineseProcessRuleItem;

    public ChineseProcessRuleEnum SelectedChineseProcessRule => SelectedChineseProcessRuleItem?.Value ?? default;
    
    partial void OnSelectedChineseProcessRuleItemChanged(
        EnumDisplayHelper.EnumDisplayItem<ChineseProcessRuleEnum>? oldValue,
        EnumDisplayHelper.EnumDisplayItem<ChineseProcessRuleEnum>? newValue)
    {
        if (newValue != null) _settingBean.Config.ChineseProcessRule = newValue.Value;
    }
    
    // 4. 主题
    public ObservableCollection<EnumDisplayHelper.EnumDisplayItem<ThemeModeEnum>> ThemeModeRules { get; } =
        EnumDisplayHelper.GetEnumDisplayCollection<ThemeModeEnum>();
    
    [ObservableProperty]
    private EnumDisplayHelper.EnumDisplayItem<ThemeModeEnum> _selectedThemeModeRuleItem;

    public ThemeModeEnum SelectedThemeModeRule => SelectedThemeModeRuleItem?.Value ?? default;
    
    partial void OnSelectedThemeModeRuleItemChanged(
        EnumDisplayHelper.EnumDisplayItem<ThemeModeEnum>? oldValue,
        EnumDisplayHelper.EnumDisplayItem<ThemeModeEnum>? newValue)
    {
        if (newValue != null) _settingBean.Config.ThemeMode = newValue.Value;
    }
    
    // 5. LRC 时间戳
    [ObservableProperty] private string _lrcTimestampFormat;
    
    partial void OnLrcTimestampFormatChanged(string value)
    {
        _settingBean.Config.LrcTimestampFormat = value;
    }
    
    // 6. SRT 时间戳
    [ObservableProperty] private string _srtTimestampFormat;
    
    partial void OnSrtTimestampFormatChanged(string value)
    {
        _settingBean.Config.SrtTimestampFormat = value;
    }
    
    // 7. SRT 时间戳
    [ObservableProperty] private bool _ignoreEmptyLyric;
    
    partial void OnIgnoreEmptyLyricChanged(bool value)
    {
        _settingBean.Config.IgnoreEmptyLyric = value;
    }
    
    // 8. SRT 时间戳
    public ObservableCollection<EnumDisplayHelper.EnumDisplayItem<VerbatimLyricModeEnum>> VerbatimLyricMode { get; } =
        EnumDisplayHelper.GetEnumDisplayCollection<VerbatimLyricModeEnum>();
    
    [ObservableProperty]
    private EnumDisplayHelper.EnumDisplayItem<VerbatimLyricModeEnum> _selectedVerbatimLyricModeItem;

    public VerbatimLyricModeEnum SelectedTVerbatimLyricMode => SelectedVerbatimLyricModeItem?.Value ?? default;
    
    partial void OnSelectedVerbatimLyricModeItemChanged(
        EnumDisplayHelper.EnumDisplayItem<VerbatimLyricModeEnum>? oldValue,
        EnumDisplayHelper.EnumDisplayItem<VerbatimLyricModeEnum>? newValue)
    {
        if (newValue != null) _settingBean.Config.VerbatimLyricMode = newValue.Value;
    }
    
    // 9. 译文匹配精度
    [ObservableProperty] private int _matchPrecisionDeviation;
    
    partial void OnMatchPrecisionDeviationChanged(int value)
    {
        _settingBean.Config.TransConfig.MatchPrecisionDeviation = value;
    }

    // 10. 百度 APP ID
    [ObservableProperty] private string _baiduAppId;
    
    partial void OnBaiduAppIdChanged(string value)
    {
        _settingBean.Config.TransConfig.BaiduTranslateAppId = value;
    }
    
    // 11. 百度密钥
    [ObservableProperty] private string _baiduSecret;
    
    partial void OnBaiduSecretChanged(string value)
    {
        _settingBean.Config.TransConfig.BaiduTranslateSecret = value;
    }
    
    // 12. 彩云小译 Token
    [ObservableProperty] private string _caiYunToken;
    
    partial void OnCaiYunTokenChanged(string value)
    {
        _settingBean.Config.TransConfig.CaiYunToken = value;
    }
    
    // 13. 跳过纯音乐
    [ObservableProperty] private bool _ignorePureMusicInSave;
    
    partial void OnIgnorePureMusicInSaveChanged(bool value)
    {
        _settingBean.Config.IgnorePureMusicInSave = value;
    }
    
    // 14. 独立歌词格式分文件保存
    [ObservableProperty] private bool _separateFileForIsolated;
    
    partial void OnSeparateFileForIsolatedChanged(bool value)
    {
        _settingBean.Config.SeparateFileForIsolated = value;
    }
    
    // 15. 保存文件名
    [ObservableProperty] private string _outputFileNameFormat;
    
    partial void OnOutputFileNameFormatChanged(string value)
    {
        _settingBean.Config.OutputFileNameFormat = value;
    }
    
    // 16. 聚合模糊搜索
    [ObservableProperty] private bool _aggregatedBlurSearch;
    
    partial void OnAggregatedBlurSearchChanged(bool value)
    {
        _settingBean.Config.AggregatedBlurSearch = value;
    }
    
    // 17. 自动读取剪切板
    [ObservableProperty] private bool _autoReadClipboard;
    
    partial void OnAutoReadClipboardChanged(bool value)
    {
        _settingBean.Config.AutoReadClipboard = value;
    }
    
    // 18. 自动检查更新
    [ObservableProperty] private bool _autoCheckUpdate;
    
    partial void OnAutoCheckUpdateChanged(bool value)
    {
        _settingBean.Config.AutoCheckUpdate = value;
    }
    
    // 19. QQ音乐 Cookie
    [ObservableProperty] private string _qqMusicCookie;
    
    partial void OnQqMusicCookieChanged(string value)
    {
        _settingBean.Config.QQMusicCookie = value;
    }
    
    // 20. 网易云 Cookie
    [ObservableProperty] private string _netEaseCookie;
    
    partial void OnNetEaseCookieChanged(string value)
    {
        _settingBean.Config.NetEaseCookie = value;
    }
    
    // 21. 歌手分隔符
    [ObservableProperty] private string _singerSeparator;
    
    partial void OnSingerSeparatorChanged(string newValue)
    {
        _settingBean.Config.SingerSeparator = newValue;
    }

    // 22. 歌词合并符
    [ObservableProperty] private string _lrcMergeSeparator;

    partial void OnLrcMergeSeparatorChanged(string value)
    {
        _settingBean.Param.LrcMergeSeparator = value;
    }
    
    private SettingBean _settingBean;

    public void Bind(SettingBean settingBean)
    {
        _settingBean = settingBean;
        
        SelectedDotTypeItem = DotTypes.First(item => Equals(item.Value, _settingBean.Config.DotType));
        SelectedTransLyricLostRuleItem = TransLyricLostRules.First(item => Equals(item.Value, _settingBean.Config.TransConfig.LostRule));
        SelectedChineseProcessRuleItem = ChineseProcessRules.First(item => Equals(item.Value, _settingBean.Config.ChineseProcessRule));
        SelectedThemeModeRuleItem = ThemeModeRules.First(item => Equals(item.Value, _settingBean.Config.ThemeMode));
        LrcTimestampFormat = _settingBean.Config.LrcTimestampFormat;
        SrtTimestampFormat = _settingBean.Config.SrtTimestampFormat;
        IgnoreEmptyLyric = _settingBean.Config.IgnoreEmptyLyric;
        SelectedVerbatimLyricModeItem = VerbatimLyricMode.First(item => Equals(item.Value, _settingBean.Config.VerbatimLyricMode));
        MatchPrecisionDeviation = _settingBean.Config.TransConfig.MatchPrecisionDeviation;
        BaiduAppId = _settingBean.Config.TransConfig.BaiduTranslateAppId;
        BaiduSecret =  _settingBean.Config.TransConfig.BaiduTranslateSecret;
        CaiYunToken = _settingBean.Config.TransConfig.CaiYunToken;
        IgnorePureMusicInSave = _settingBean.Config.IgnorePureMusicInSave;
        SeparateFileForIsolated = _settingBean.Config.SeparateFileForIsolated;
        OutputFileNameFormat = _settingBean.Config.OutputFileNameFormat;
        AggregatedBlurSearch = _settingBean.Config.AggregatedBlurSearch;
        AutoReadClipboard = _settingBean.Config.AutoReadClipboard;
        AutoCheckUpdate = _settingBean.Config.AutoCheckUpdate;
        QqMusicCookie = _settingBean.Config.QQMusicCookie;
        NetEaseCookie = _settingBean.Config.NetEaseCookie;
        SingerSeparator = _settingBean.Config.SingerSeparator;
        LrcMergeSeparator = _settingBean.Param.LrcMergeSeparator;
    }
}
