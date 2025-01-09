using SocNetBack.Domain.ValueObjects;

namespace SocNetBack.Domain.Models;

public class Comment
{
    public int CommentId { get; }
    public string Body { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    public List<MediaFile> MediaFiles { get; }
}