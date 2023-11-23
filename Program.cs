using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

class Program
{
    public static void OpenApp()
    {
        // 12345
        /*Output*/
        Console.WriteLine("||========================================||");
        Console.WriteLine("||====                                ====||");
        Console.WriteLine("||==         Welcome to Petroom         ==||");
        Console.WriteLine("||====                                ====||");
        Console.WriteLine("||========================================||");

    }
    public static List<User> DefaultUser()
    {
        List<User> users = new List<User>();
        users.Add(new User(1, "Jiramet", "asdfghjkl", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(2, "Yomu", "qwerty", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(3, "Akira", "zxcvbnm", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(3, "jiramet", "qazwsx", 18, "0610614617", "Image", "jib8147@gmail.com"));
        return users;
    }

    public static List<Pet> DefaultPet()
    {
        List<Pet> pets = new List<Pet>();
        pets.Add(new Pet(1, 1, "Bobby", "12Y", "Dog", "Mix", "Image", "Male", "-", "None", "Kind", "-"));
        pets.Add(new Pet(2, 1, "Cookie", "5M", "Cat", "Mix", "Image", "Male", "-", "None", "Kind", "-"));
        pets.Add(new Pet(3, 2, "Fuji", "5M", "Cat", "Mix", "Image", "Female", "-", "None", "Kind", "-"));
        return pets;
    }

    public static void Profile(User user)
    {
        Console.WriteLine("||==============Profile User==============||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        Console.WriteLine("||Username : {0}", user.Username);
        Console.WriteLine("||Age : {0}", user.Age);
        Console.WriteLine("||Number : {0}", user.Number);
        Console.WriteLine("||Image : {0}", user.ImageUser);
        Console.WriteLine("||Email : {0}", user.Email);
        Console.WriteLine("||==============Profile Pet===============||");
        if (user.Pets != null && user.Pets.Any())
        {
            foreach (Pet pet in user.Pets)
            {
                Console.WriteLine("||Name : {0}", pet.Name);
                Console.WriteLine("||Age : {0}", pet.Age);
                Console.WriteLine("||Specie : {0} {1}", pet.Specie, pet.Breed);
                Console.WriteLine("||Sex : {0}", pet.Sex);
                Console.WriteLine("||Status : {0}", pet.Status);
                Console.WriteLine("||Image: {0}", pet.ImagePet);
                Console.WriteLine("||Trait : {0}", pet.Trait);
                Console.WriteLine("||Medical History : {0}", pet.MHistory);
                Console.WriteLine("||Description : {0}", pet.Description);
                Console.WriteLine("||----------------------------------------||");
            }
        }
        else
        {
            Console.WriteLine("||---------------None!!-------------------||");
        }
        Console.WriteLine("||========================================||");
    }

    public static User SignIn(int idUser)
    {
        Console.WriteLine("||================Sign In=================||");
        Console.Write("||Username : ");
        string usernameSignIn = Console.ReadLine();
        Console.Write("||Password : ");
        string passwordSignIn = Console.ReadLine();
        Console.Write("||Age : ");
        int ageSignIn = int.Parse(Console.ReadLine());
        Console.Write("||Number : ");
        string numberSignIn = Console.ReadLine();
        Console.Write("||Image : ");
        string imageUserSignIn = Console.ReadLine();
        Console.Write("||Email : ");
        string emailSignIn = Console.ReadLine();
        Console.WriteLine("||=============Sign In Complete===========||");
        return new User(idUser, usernameSignIn, passwordSignIn, ageSignIn, numberSignIn, imageUserSignIn, emailSignIn);
    }

    public static User LogIn(List<User> users)
    {
        Console.WriteLine("||=================Log In=================||");
        Console.Write("||Username : ");
        string usernameLogIn = Console.ReadLine();
        Console.Write("||Password : ");
        string passwordLogIn = Console.ReadLine();
        Console.WriteLine("||========================================||");
        User userLoginComplete = null;
        foreach (User user in users)
        {
            if ((user.Username == usernameLogIn || user.Email == usernameLogIn) && user.Password == passwordLogIn)
            {
                userLoginComplete = user;
                break;
            }
            else
            {
                userLoginComplete = null;
            }
        }

        if (userLoginComplete != null)
        {
            Console.WriteLine("||=============Log In Complete============||");
        }
        else
        {
            Console.WriteLine("||=============Worng Password=============||");
        }

        return userLoginComplete;
    }

    public static void SearchUI(List<User> users, List<Pet> pets)
    {
        Console.WriteLine("||=================Search=================||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        Console.Write("||Keyword : ");
        string keyword = Console.ReadLine();
        Console.WriteLine("||----------------------------------------||");
        bool check = true;
        foreach (User user in users)
        {
            User Find = Search(keyword, user);
            if (Find != null)
            {
                while (true)
                {
                    Profile(Find);
                    check = false;
                    break;
                }
            }
        }

        foreach (Pet pet in pets)
        {
            int idUser = Search(keyword, pet);
            if (idUser >= 0)
            {
                while (true)
                {
                    Profile(users[idUser - 1]);
                    check = false;
                    break;
                }
            }

        }
        if (Search(keyword, users[users.Count - 1]) == null && check)
        {
            Console.WriteLine("||Not Found!!");
            check = false;
        }
        if (Search(keyword, users[users.Count - 1]) == null && check)
        {
            Console.WriteLine("||Not Found!!");
        }
        Console.WriteLine("||===============End of Search============||");
    }

    public static User Search(string keyword, User user)
    {
        if (user.Username.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return user;
        }
        return null;
    }

    public static int Search(string keyword, Pet pet)
    {
        if (pet.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || pet.Specie.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || pet.Breed.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return pet.UserId;
        }
        return -1;
    }

    public static Pet AddPetUI(int idPet, int idUser)
    {
        Console.WriteLine("|=================Add Pet================||");
        Console.Write("||Name : ");
        string name = Console.ReadLine();
        Console.Write("||Age : ");
        string age = Console.ReadLine();
        Console.Write("||Specie : ");
        string specie = Console.ReadLine();
        Console.Write("||Breed : ");
        string breed = Console.ReadLine();
        Console.Write("||Image Pet : ");
        string imagePet = Console.ReadLine();
        Console.Write("||Sex : ");
        string sex = Console.ReadLine();
        Console.Write("||Status : ");
        string status = Console.ReadLine();
        Console.Write("||Trait : ");
        string trait = Console.ReadLine();
        Console.Write("||Medical History : ");
        string mHistory = Console.ReadLine();
        Console.Write("||Description : ");
        string description = Console.ReadLine();
        Console.WriteLine("||=============Add Pet Complete===========||");
        return new Pet(idPet, idUser, name, age, specie, breed, imagePet, sex, status, mHistory, trait, description);
    }

    public static void FeedHeadlineText()
    {
        Console.WriteLine("||==================Feed==================||");
        Console.WriteLine("||-[Press + to add Post]------------------||");
        Console.WriteLine("||========================================||");
    }

    public static void Feed(List<User> users, User currentUser)
    {
        FeedHeadlineText();
        bool checkPost = false;
        foreach (User user in users)
        {
            if (user.Posts.Count != 0)
            {
                int idPost = 0;
                ConsoleKeyInfo key;
                do
                {
                    Console.Clear();
                    FeedHeadlineText();
                    PostUI(user.Posts[idPost], user);
                    key = Console.ReadKey();
                    if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.D) && idPost < user.Posts.Count - 1)
                    {
                        idPost++;
                    }
                    else if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.A) && idPost > 0)
                    {
                        idPost--;
                    }
                    else if (key.Key == ConsoleKey.OemPlus)
                    {
                        AddPost(currentUser);
                        Feed(users, currentUser);
                    }
                    else if (key.Key == ConsoleKey.L)
                    {
                        user.Posts[idPost].Like++;
                    }
                    else if (key.Key == ConsoleKey.R)
                    {
                        CommentPost(user.Posts[idPost], users, currentUser);
                    }
                } while (key.Key != ConsoleKey.Enter);
            }
            else
            {
                checkPost = true;
            }
        }
        if (checkPost)
        {
            Console.WriteLine("||None Post!!");
        }
    }

    public static void CommentPost(Post post, List<User> users, User currentUser)
    {
        Console.WriteLine("|================Comment=================||");
        Console.WriteLine("||-[Press + to Comment]------------------||");
        foreach (Comment comment in post.Comment)
        {
            string username = "";
            foreach (User user in users)
            {
                if (user.UserId == comment.UserId)
                {
                    username = user.Username;
                }
            }
            Console.WriteLine($"||Username : {username}");
            Console.WriteLine($"||Comment : {comment.CommentText}");
            Console.WriteLine("||========================================||");
        };
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.OemPlus)
            {
                Console.Clear();
                post.Comment.Add(AddComment(currentUser));
            }
        } while (key.Key != ConsoleKey.Enter);
    }

    public static Comment AddComment(User currentUser)
    {
        Console.WriteLine("||================Comment=================||");
        Console.Write("||Comment : ");
        string comment = Console.ReadLine();
        Console.WriteLine("||========================================||");
        return new Comment(currentUser.UserId, comment);
    }

    public static void PostUI(Post post, User user)
    {
        Console.WriteLine($"||Topic : {post.Topic}");
        Console.WriteLine($"||Content : {post.Content}");
        Console.WriteLine($"||Post by {user.Username}");
        Console.WriteLine($"||LIke : {post.Like} Comment : {post.Comment.Count}");
        Console.WriteLine("||-[Press l to like and r to read comment]||");
        Console.WriteLine("||-[Press Enter and Esc to go Menu]-------||");
        Console.WriteLine("||========================================||");
    }

    public static void AddPost(User currentUser)
    {
        Console.Clear();
        Console.WriteLine("||==================Post==================||");
        Console.Write("||Topic : ");
        string topic = Console.ReadLine();
        Console.Write("||Content : ");
        string content = Console.ReadLine();
        currentUser.AddPosts(new Post(currentUser.Posts.Count, currentUser.UserId, topic, content, 0));
        Console.WriteLine("||========================================||");
    }

    public static void Chat(List<User> users)
    {
        ConsoleKeyInfo key;
        Console.WriteLine("||======Search User You Want To Chat======||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        Console.Write("||Keyword : ");
        string keyword = Console.ReadLine();
        Console.WriteLine("||----------------------------------------||");
        bool check = true;
        while (check)
        {
            foreach (User user in users)
            {
                User Find = Search(keyword, user);
                if (Find != null)
                {
                    Console.WriteLine("You are current chat with " + user.Username);
                }
            }
            if (Search(keyword, users[users.Count - 1]) == null && check)
            {
                Console.WriteLine("||Not Found!!");
                check = false;
            }
        }
        Console.WriteLine("||===============End of Search============||");
        do
        {
            key = Console.ReadKey();
        } while (key.Key != ConsoleKey.Escape);
    }
    public static void GroupChat(List<User> users)
    {
        List<string> groupMember = new List<string>();
        ConsoleKeyInfo key;
        do
        {
            Console.WriteLine("||Search User You Want To Add To Group Chat||");
            Console.WriteLine("||-[Esc to Exit]--------------------------||");
            Console.Write("||Keyword : ");
            string keyword = Console.ReadLine();
            Console.WriteLine("||----------------------------------------||");
            bool check = true;
            while (check)
            {
                foreach (User user in users)
                {
                    User Find = Search(keyword, user);
                    if (Find != null)
                    {
                        groupMember.Add(user.Username);
                        Console.WriteLine("Current Member In Group Chat :");
                        foreach (string member in groupMember)
                        {
                            Console.WriteLine(member);
                        }
                    }
                }
                if (Search(keyword, users[users.Count - 1]) == null && check)
                {
                    Console.WriteLine("||Not Found!!");
                    check = false;
                }
            }
            Console.WriteLine("||===============End of Search============||");
            key = Console.ReadKey();
        } while (key.Key != ConsoleKey.Escape);
    }

    public static bool LogInOrSignIn()
    {
        string[] options = { "Log In", "Sign In" };
        int selectedIndex = 0;
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            OpenApp();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write("||");
                Console.WriteLine(options[i]);

                Console.ResetColor();

            }

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;
                case ConsoleKey.A:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;

                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;
                case ConsoleKey.D:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;
            }

        } while (key.Key != ConsoleKey.Enter);

        Console.Clear();
        if (options[selectedIndex].Contains("Sign In"))
        {
            return true;
        }
        return false;
    }

    public static string Home()
    {
        string[] options = { "Search", "Feed", "Profile", "Match", "Chat", "Group" };
        int selectedIndex = 0;
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.Write("||");
                Console.WriteLine(options[i]);

                Console.ResetColor();
            }

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;
                case ConsoleKey.A:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;
                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;
                case ConsoleKey.D:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.Clear();
        if (options[selectedIndex].Contains("Search"))
        {
            return "Search";
        }
        else if (options[selectedIndex].Contains("Feed"))
        {
            return "Feed";
        }
        else if (options[selectedIndex].Contains("Profile"))
        {
            return "Profile";
        }
        else if (options[selectedIndex].Contains("Group"))
        {
            return "Group";
        }
        else if (options[selectedIndex].Contains("Chat"))
        {
            return "Chat";
        }
        else
        {
            return "Match";
        }
    }

    public static void pathHome(string path, List<User> users, List<Pet> pets, User currentUser)
    {
        ConsoleKeyInfo key;

        foreach (User user in users)
        {
            foreach (Pet pet in pets)
            {
                if (user.UserId == pet.UserId)
                {
                    user.AddPets(pet);
                }
            };
        }

        switch (path)
        {
            case "Search":
                Console.Clear();
                SearchUI(users, pets);
                do
                {
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser);
                break;
            case "Feed":
                Console.Clear();
                Feed(users, currentUser);
                do
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.OemPlus)
                    {
                        AddPost(currentUser);
                    }
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser);
                break;
            case "Profile":
                Console.Clear();
                Profile(currentUser);
                do
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.OemPlus)
                    {
                        Pet newPet = AddPetUI(pets.Count, currentUser.UserId);
                        pets.Add(newPet);
                        Console.Clear();
                    }
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser);
                break;
            case "Group":
                Console.Clear();
                GroupChat(users);
                do
                {
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser);
                break;
            case "Chat":
                Console.Clear();
                Chat(users);
                do
                {
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser);
                break;
            case "Match":
                break;
            case "Home":
                Console.Clear();
                path = Home();
                pathHome(path, users, pets, currentUser);
                break;
            default:
                Console.Clear();
                Console.WriteLine("404 Not Found");
                break;
        }
    }

    public static void Main(string[] args)
    {
        List<User> users = DefaultUser();
        List<Pet> pets = DefaultPet();
        string path = "Home";
        User currentUser;

        bool logInOrSignIn = LogInOrSignIn();
        if (logInOrSignIn)
        {
            currentUser = SignIn(users.Count);
            if (currentUser != null)
            {
                users.Add(currentUser);
                Console.Clear();
                path = Home();
                pathHome(path, users, pets, currentUser);
            }
        }
        else
        {
            currentUser = LogIn(users);
            if (currentUser != null)
            {
                Console.Clear();
                path = Home();
                pathHome(path, users, pets, currentUser);
            }
        }
    }

}