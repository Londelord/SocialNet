using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class VideoFile : MediaFile
{
    public TimeSpan Duration { get; }

    private static readonly HashSet<string> AllowedExtensions = new() { ".mp4", ".avi", ".mkv" };

    private VideoFile(string path, TimeSpan duration)
        : base(MediaType.Video, path)
    {
        Duration = duration;
    }

    public static Result<VideoFile> Create(string path, TimeSpan duration)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Result.Failure<VideoFile>("Path cannot be empty.");

        if (!Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
            return Result.Failure<VideoFile>("Invalid path format.");

        var extension = System.IO.Path.GetExtension(path).ToLower();
        if (!AllowedExtensions.Contains(extension))
            return Result.Failure<VideoFile>($"Unsupported video format: {extension}");

        return Result.Success(new VideoFile(path, duration));
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var component in base.GetEqualityComponents())
            yield return base.GetEqualityComponents();
        yield return Duration;
    }
}