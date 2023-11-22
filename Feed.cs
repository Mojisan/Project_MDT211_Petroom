public class Comment
{
    public int UserId { get; set; }
    public string CommentText { get; set; }

    public Comment(int UserId, string CommentText)
    {
        this.UserId = UserId;
        this.CommentText = CommentText;
    }
}

public class Post
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Topic { get; set; }
    public string Content { get; set; }
    public int Like { get; set; }
    public List<Comment> Comment;

    public Post(
        int PostId,
        int UserId,
        string Topic,
        string Content,
        int Like
        )
    {
        this.PostId = PostId;
        this.UserId = UserId;
        this.Topic = Topic;
        this.Content = Content;
        this.Like = Like;
        this.Comment = new List<Comment>();
    }
}
