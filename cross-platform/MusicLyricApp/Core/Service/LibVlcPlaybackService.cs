using System;
using LibVLCSharp.Shared;

namespace MusicLyricApp.Core.Service;

public sealed class LibVlcPlaybackService : IPlaybackService
{
    private readonly LibVLC _libVlc;
    private readonly MediaPlayer _player;
    private Media? _media;
    private string _currentUrl = string.Empty;

    public LibVlcPlaybackService()
    {
        LibVLCSharp.Shared.Core.Initialize();
        _libVlc = new LibVLC("--no-video");
        _player = new MediaPlayer(_libVlc);
    }

    public bool HasMedia => _player.Media != null;
    public bool IsPlaying => _player.IsPlaying;
    public double PositionSeconds => Math.Max(0, _player.Time / 1000d);
    public double DurationSeconds => Math.Max(0, _player.Length / 1000d);
    public string CurrentMediaUrl => _currentUrl;

    public bool Prepare(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        if (HasMedia && string.Equals(_currentUrl, url, StringComparison.Ordinal))
        {
            return true;
        }

        Stop();

        _media?.Dispose();
        _media = new Media(_libVlc, new Uri(url));
        _player.Media = _media;
        _currentUrl = url;
        return true;
    }

    public void Play()
    {
        _player.Play();
    }

    public void Pause()
    {
        _player.Pause();
    }

    public void Stop()
    {
        _player.Stop();
    }

    public void Seek(double seconds)
    {
        if (!HasMedia)
        {
            return;
        }

        var safe = Math.Max(0, seconds);
        _player.Time = (long)(safe * 1000);
    }

    public void Dispose()
    {
        try
        {
            _player.Stop();
        }
        catch
        {
            // ignore shutdown errors
        }

        _media?.Dispose();
        _player.Dispose();
        _libVlc.Dispose();
    }
}
