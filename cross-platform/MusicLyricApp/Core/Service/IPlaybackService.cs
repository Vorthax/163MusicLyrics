using System;

namespace MusicLyricApp.Core.Service;

public interface IPlaybackService : IDisposable
{
    bool HasMedia { get; }
    bool IsPlaying { get; }
    double PositionSeconds { get; }
    double DurationSeconds { get; }
    string CurrentMediaUrl { get; }

    bool Prepare(string url);
    void Play();
    void Pause();
    void Stop();
    void Seek(double seconds);
}
