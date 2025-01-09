using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public abstract class MediaFile : ValueObject
{
    public MediaType MediaType { get; }
    public string Path { get; }
    
    protected MediaFile(MediaType mediaType, string path)
    {
        MediaType = mediaType;
        Path = path;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return MediaType;
        yield return Path;
    }
}