public class Post
{
    public string UserId { get; set; }
    public string Topic { get; set; }
    public string Content { get; set; }
    public int CountLike { get; set; }

    public Post(
        string Topic,
        string Content,
        int CountLike
        )
    {
        this.Topic = Topic;
        this.Content = Content;
        this.CountLike = CountLike;
    }
}

public class Feed
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public List<Post> Posts;
    public string Comment { get; set; }
    public bool Like { get; set; }

    public Feed(
        int PostId,
        string Comment,
        bool Like
    )
    {
        this.PostId = PostId;
        this.Posts = new List<Post>();
        this.Comment = Comment;
        this.Like = Like;
    }

    public void AddPost(Post post)
    {
        Posts.Add(post);
    }
}