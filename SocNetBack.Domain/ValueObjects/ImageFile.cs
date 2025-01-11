using CSharpFunctionalExtensions;

namespace SocNetBack.Domain.ValueObjects;

public class ImageFile : MediaFile
{
    public static readonly HashSet<string> AllowedExtensions = [".jpg", ".jpeg", ".png", ".gif"];

    private ImageFile(string path) :
        base(MediaType.Image, path) {}

    public static Result<ImageFile> Create(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Result.Failure<ImageFile>("Path cannot be empty.");

        if (!Uri.IsWellFormedUriString(path, UriKind.RelativeOrAbsolute))
            return Result.Failure<ImageFile>("Invalid path format.");

        var extension = System.IO.Path.GetExtension(path.ToLower());
        if (!AllowedExtensions.Contains(extension))
            return Result.Failure<ImageFile>($"Unsupported image format: {extension}");

        return Result.Success(new ImageFile(path));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var component in base.GetEqualityComponents())
            yield return base.GetEqualityComponents();
    }
}