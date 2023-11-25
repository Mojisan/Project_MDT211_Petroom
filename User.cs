public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public string Number { get; set; }
    public string ImageUser { get; set; }
    public string Email { get; set; }
    public List<Pet> Pets;
    public List<Post> Posts;

    public User(
        int UserId,
        string Username,
        string Password,
        int Age,
        string Number,
        string ImageUser,
        string Email
        )
    {
        this.UserId = UserId;
        this.Username = Username;
        this.Password = Password;
        this.Age = Age;
        this.Number = Number;
        this.ImageUser = ImageUser;
        this.Email = Email;
        this.Pets = new List<Pet>();
        this.Posts = new List<Post>();
    }

    public void AddPets(Pet pet)
    {
        Pets.Add(pet);
    }
    public void AddPosts(Post post)
    {
        Posts.Add(post);
    }
}

public class Group
{
    public string GroupName { get; set; }
    public List<User> member;

    public Group(string name)
    {
        this.GroupName = name;
        this.member = new List<User>();
    }

    public void JoinGroup(User user)
    {
        member.Add(user);
    }
}