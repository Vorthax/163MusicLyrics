using CommunityToolkit.Mvvm.Messaging.Messages;
using MusicLyricApp.Models;

namespace MusicLyricApp.ViewModels.Messages;

public record SongDetailRequest(string SongId, SearchSourceEnum SearchSource);

public class OpenSongDetailMessage(SongDetailRequest value) : ValueChangedMessage<SongDetailRequest>(value);
