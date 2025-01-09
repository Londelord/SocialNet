using CSharpFunctionalExtensions;
using SocNetBack.Domain.ValueObjects;

namespace SocNetBack.Domain.Models;

public class Post
{
    public Guid PostId { get; }
    public Guid AuthorId { get; }
    public string Body { get; }
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; }
    public int LikesCount { get; private set; }
    public int ViewsCount { get; private set; }
    public HashSet<Comment> Comments { get; }
    public bool IsCommunityPost { get; }
    public Guid? CommunityId { get; }
    public HashSet<MediaFile> MediaFiles { get; }
    public HashSet<Tag> Tags { get; }
    public HashSet<Restriction> Restrictions { get; }

    //TODO - add IReadOnlyCollection
    //TODO - change HashSets
    //TODO - add management methods
    
    #region Validation constants

    public const int MAX_MEDIA_FILE_COUNT = 10;
    public const int MAX_BODY_SIZE = 5000;

    #endregion
    
    public Post(Guid postId, 
        Guid authorId, 
        string body, 
        DateTime createdAt, 
        DateTime? updatedAt, 
        int likesCount, 
        int viewsCount, 
        HashSet<Comment> comments, 
        bool isCommunityPost, 
        Guid? communityId, 
        HashSet<MediaFile> mediaFiles, 
        HashSet<Tag> tags, 
        HashSet<Restriction> restrictions)
    {
        PostId = postId;
        AuthorId = authorId;
        Body = body;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        LikesCount = likesCount;
        ViewsCount = viewsCount;
        Comments = comments;
        IsCommunityPost = isCommunityPost;
        CommunityId = communityId;
        MediaFiles = mediaFiles;
        Tags = tags;
        Restrictions = restrictions;
    }
    
    public Result<Post> Create(Guid postId, 
        Guid authorId, 
        string body, 
        DateTime createdAt, 
        DateTime? updatedAt, 
        int likesCount, 
        int viewsCount, 
        HashSet<Comment> comments, 
        bool isCommunityPost, 
        Guid? communityId, 
        HashSet<MediaFile> mediaFiles, 
        HashSet<Tag> tags, 
        HashSet<Restriction> restrictions)
    {
        var validationResult = IsValid(body, createdAt, updatedAt, likesCount, viewsCount, isCommunityPost,
            communityId, mediaFiles);
        
        if (validationResult.IsFailure)
            return Result.Failure<Post>(validationResult.Error);
        
        return Result.Success(new Post(postId, authorId, body, 
            createdAt, updatedAt, likesCount, viewsCount, 
            comments, isCommunityPost, communityId, mediaFiles, 
            tags, restrictions));
    }

    private Result IsValid(string body, DateTime createdAt, DateTime? updatedAt, 
        int likesCount, int viewsCount, bool isCommunityPost, Guid? communityId, HashSet<MediaFile> mediaFiles)
    {
        if (string.IsNullOrWhiteSpace(body))
            return Result.Failure<Post>("Body is required");
        
        if (body.Length > MAX_BODY_SIZE)
            return Result.Failure<Post>("Body is too long");
        
        if (createdAt > updatedAt)
            return Result.Failure<Post>("Created time cannot be after updated");
        
        if (createdAt > DateTime.UtcNow)
            return Result.Failure<Post>("Created time cannot be in the future");
        
        if (updatedAt > DateTime.UtcNow)
            return Result.Failure<Post>("Updated time cannot be in the future");
        
        if (likesCount < 0)
            return Result.Failure<Post>("LikesCount cannot be negative");
        
        if (viewsCount < 0)
            return Result.Failure<Post>("Views count cannot be negative");
        
        if (isCommunityPost && communityId == null)
            return Result.Failure<Post>("Community ID cannot be null");
        
        if (mediaFiles.Count > MAX_MEDIA_FILE_COUNT)
            return Result.Failure<Post>("Media files count cannot be greater than maximum of 10");
        
        return Result.Success();
    }
    
    public void AddLike() => LikesCount++;
    
    public void AddView() => ViewsCount++;
    
    public void AddComment(Comment comment) => Comments.Add(comment);
}