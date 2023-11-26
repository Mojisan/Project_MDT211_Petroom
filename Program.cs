using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

class Program
{
    public static void OpenApp()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||==============Profile User==============||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"||Username : {user.Username}");
        Console.WriteLine($"||Age : {user.Age}");
        Console.WriteLine($"||Number : {user.Number}");
        Console.WriteLine($"||Image : {user.ImageUser}");
        Console.WriteLine($"||Email : {user.Email}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||==============Profile Pet===============||");
        if (user.Pets.Count > 0)
        {
            foreach (Pet pet in user.Pets)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"||Name : {pet.Name}");
                Console.WriteLine($"||Age : {pet.Age}");
                Console.WriteLine($"||Specie : {pet.Specie} {pet.Breed}");
                Console.WriteLine($"||Sex : {pet.Sex}");
                Console.WriteLine($"||Status : {pet.Status}");
                Console.WriteLine($"||Image: {pet.ImagePet}");
                Console.WriteLine($"||Trait : {pet.Trait}");
                Console.WriteLine($"||Medical History : {pet.MHistory}");
                Console.WriteLine($"||Description : {pet.Description}");
                Console.WriteLine("||----------------------------------------||");
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("||---------------None!!-------------------||");
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||========================================||");
    }

    public static string HiddenPassword()
    {
        string input = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter)
            {
                input += key.KeyChar;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("*");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine("");
        return input;
    }

    public static User SignIn(int idUser)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("||================Sign In=================||");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("||Username : ");
        string usernameSignIn = Console.ReadLine();
        Console.Write("||Password : ");
        string passwordSignIn = HiddenPassword();
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
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("||=================Log In=================||");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("||Username : ");
        string usernameLogIn = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("||Password : ");
        string passwordLogIn = HiddenPassword();
        Console.ForegroundColor = ConsoleColor.Blue;
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("||=============Log In Complete============||");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("||=============Worng Password=============||");
        }

        return userLoginComplete;
    }

    public static void SearchUI2(List<User> users, List<Pet> pets, User currentUser, List<Group> groups)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||=================Search=================||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        Console.Write("||Keyword : ");
        string keyword = Console.ReadLine();
        Console.WriteLine("||----------------------------------------||");
        List<string> Option = new List<string>();
        foreach (User user in users)
        {
            if (user.Username.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                Option.Add(user.Username);
            }
        }

        foreach (Pet pet in pets)
        {
            if ((pet.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0) || (pet.Specie.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                Option.Add(pet.Name);
            }
        }

        ConsoleKeyInfo key;
        int selectedIndex = 0;
        do
        {
            if (Option.Count > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||=================Search=================||");
                for (int i = 0; i < Option.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("||");
                    Console.WriteLine(Option[i]);

                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("||Not found!!");
            }

            key = Console.ReadKey();

            if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && selectedIndex < Option.Count - 1)
            {
                selectedIndex++;
            }
            else if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && selectedIndex > 0)
            {
                selectedIndex--;
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                pathHome("Home", users, pets, currentUser, groups);
            }

        } while (key.Key != ConsoleKey.Enter);

        Console.Clear();
        foreach (User user in users)
        {
            if (user.Username.Contains(Option[selectedIndex]))
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Profile(user);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("||-[C to Chat]----------------------------||");
                do
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.C)
                    {
                        Chat(user, currentUser);
                    }
                } while (key.Key != ConsoleKey.Escape);
            }
        }
        foreach (Pet pet in pets)
        {
            if (pet.Name.Contains(Option[selectedIndex]) || pet.Specie.Contains(Option[selectedIndex]))
            {
                Profile(users[pet.UserId - 1]);
                Console.WriteLine("||-[C to Chat]----------------------------||");
                do
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.C)
                    {
                        Chat(users[pet.UserId - 1], currentUser);
                    }
                } while (key.Key != ConsoleKey.Escape);
            }
        }
    }

    public static Pet AddPetUI(int idPet, int idUser)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("|=================Add Pet================||");
        Console.ForegroundColor = ConsoleColor.White;
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("||=============Add Pet Complete===========||");
        return new Pet(idPet, idUser, name, age, specie, breed, imagePet, sex, status, mHistory, trait, description);
    }

    public static void FeedHeadlineText()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
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
                    if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && idPost < user.Posts.Count - 1)
                    {
                        idPost++;
                    }
                    else if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && idPost > 0)
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
            Console.ForegroundColor = ConsoleColor.Red;
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
        Console.ForegroundColor = ConsoleColor.Cyan;
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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("||==================Post==================||");
        Console.Write("||Topic : ");
        string topic = Console.ReadLine();
        Console.Write("||Content : ");
        string content = Console.ReadLine();
        currentUser.AddPosts(new Post(currentUser.Posts.Count, currentUser.UserId, topic, content, 0));
        Console.WriteLine("||========================================||");
    }

    public static void MatchUI(List<Pet> pets_User, List<Pet> pets, List<User> users)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||=================Match==================||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        Console.WriteLine("||----------------------------------------||");
        List<string> pet_name = new List<string>();
        int selectedIndex = 0;
        ConsoleKeyInfo key;
        foreach (Pet pet_User in pets_User)
        {
            pet_name.Add(pet_User.Name);
        }

        do
        {
            if (pet_name.Count > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||=================Your Pet===============||");
                for (int i = 0; i < pet_name.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("||");
                    Console.WriteLine(pet_name[i]);

                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("||You don't have pet!!");
            }

            key = Console.ReadKey();

            if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && selectedIndex < pet_name.Count - 1)
            {
                selectedIndex++;
            }
            else if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && selectedIndex > 0)
            {
                selectedIndex--;
            }
        } while (key.Key != ConsoleKey.Enter);

        if (pet_name.Count > 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("||=================Match==================||");
            Console.WriteLine("||-[Esc to Exit]--------------------------||");
            Console.WriteLine("||----------------------------------------||");
            Pet selectPetUser = pets_User[selectedIndex];
            List<Pet> selectPetSystem = new List<Pet>();
            foreach (Pet pet in pets)
            {
                if (selectPetUser.Specie.IndexOf(pet.Specie, StringComparison.OrdinalIgnoreCase) >= 0 && selectPetUser.Sex != pet.Sex)
                {
                    selectPetSystem.Add(pet);
                }
            }
            selectedIndex = 0;
            do
            {
                if (selectPetSystem.Count > 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("||=============Compatible Pets============||");
                    Console.WriteLine("||-[Esc to Exit]--------------------------||");
                    for (int i = 0; i < selectPetSystem.Count; i++)
                    {
                        if (i == selectedIndex)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("||");
                        Console.WriteLine(selectPetSystem[i].Name);

                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("||Don't match your pet!!");
                }

                key = Console.ReadKey();

                if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && selectedIndex < pet_name.Count - 1)
                {
                    selectedIndex++;
                }
                else if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && selectedIndex > 0)
                {
                    selectedIndex--;
                }
            } while (key.Key != ConsoleKey.Enter);

            if (selectPetSystem.Count > 0)
            {
                Console.Clear();
                Profile(users[selectPetSystem[selectedIndex].UserId]);
                do
                {
                    Chat(users[selectPetSystem[selectedIndex].UserId - 1], users[pets_User[0].UserId - 1]);
                } while (key.Key != ConsoleKey.Enter);
            }
        }
    }

    public static void Chat(User user, User currentUser)
    {
        Console.Clear();
        ConsoleKeyInfo key;
        Console.WriteLine("||==================Chat==================||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        Console.WriteLine("||You are current chat with " + user.Username);
        do
        {
            key = Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("||Message : ");
            string text = Console.ReadLine();
            Console.WriteLine($"||{currentUser.Username} : {text}");
        } while (key.Key != ConsoleKey.Escape);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Profile(user);
    }

    public static void GroupUI(User currentUser, List<Group> groups)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||=================Group==================||");
        Console.WriteLine("||-[Esc to Exit]--------------------------||");
        List<string> nameGroup = new List<string>();
        ConsoleKeyInfo key;
        int selectedIndex = 0;
        foreach (Group group in groups)
        {
            nameGroup.Add(group.GroupName);
        }
        do
        {
            if (nameGroup.Count > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||==============Choose Group==============||");
                for (int i = 0; i < nameGroup.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("||");
                    Console.WriteLine(nameGroup[i]);

                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("||None group!!");
            }
            key = Console.ReadKey();
            if ((key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D) && selectedIndex < nameGroup.Count - 1)
            {
                selectedIndex++;
            }
            else if ((key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A) && selectedIndex > 0)
            {
                selectedIndex--;
            }
            else if (key.Key == ConsoleKey.OemPlus)
            {
                groups.Add(CreateGroup(currentUser));
                Console.Clear();
                GroupUI(currentUser, groups);
            }
        } while (key.Key != ConsoleKey.Enter);

        do
        {
            Console.Clear();
            GroupMember(groups[selectedIndex]);
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.J)
            {
                groups[selectedIndex].JoinGroup(currentUser);
            }
        } while (key.Key != ConsoleKey.Enter);
    }

    public static Group CreateGroup(User currentUser)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||==============Create Group=============||");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("||Group Name : ");
        string groupName = Console.ReadLine();
        Group newGroup = new Group(groupName, currentUser);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||=======================================||");
        return newGroup;
    }

    public static void GroupMember(Group group)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||=================Group=================||");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"||Group Name : {group.GroupName}");
        Console.WriteLine("||Member : ");
        foreach (User groupMember in group.member)
        {
            Console.WriteLine($"||{groupMember.Username}");
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("||-[Press J to Join Group]---------------||");
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
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
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
        string[] options = { "Search", "Feed", "Profile", "Match", "Group" };
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
                Console.ForegroundColor = ConsoleColor.DarkCyan;
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
        else
        {
            return "Match";
        }
    }

    public static void MatchPetAndUser(List<User> users, List<Pet> pets, Pet pet)
    {
        pets.Add(pet);
        foreach (User user in users)
        {
            if (user.UserId == pets[pets.Count - 1].UserId)
            {
                user.AddPets(pet);
            }

        }
    }

    public static void pathHome(string path, List<User> users, List<Pet> pets, User currentUser, List<Group> groups)
    {
        ConsoleKeyInfo key;

        switch (path)
        {
            case "Search":
                Console.Clear();
                SearchUI2(users, pets, currentUser, groups);
                do
                {
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser, groups);
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
                pathHome("Home", users, pets, currentUser, groups);
                break;
            case "Profile":
                Console.Clear();
                Profile(currentUser);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||-[Press + to Add Pet]------------------||");
                do
                {
                    key = Console.ReadKey();
                    if (key.Key == ConsoleKey.OemPlus)
                    {
                        Pet newPet = AddPetUI(pets.Count, currentUser.UserId);
                        MatchPetAndUser(users, pets, newPet);
                        Console.Clear();
                    }
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser, groups);
                break;
            case "Group":
                GroupUI(currentUser, groups);
                /* Console.Write("InputNameGroup : ");
                string nameGroup = Console.ReadLine();
                groups.Add(new Group(nameGroup, currentUser));
                Console.WriteLine(groups[0].GroupName);
                Console.WriteLine(groups[0].member.Count);
                foreach (Group group in groups)
                {
                    Console.WriteLine(group.GroupName);
                } */
                do
                {
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser, groups);
                break;
            case "Match":
                Console.Clear();
                MatchUI(currentUser.Pets, pets, users);
                do
                {
                    key = Console.ReadKey();
                } while (key.Key != ConsoleKey.Escape);
                pathHome("Home", users, pets, currentUser, groups);
                break;
            case "Home":
                Console.Clear();
                path = Home();
                pathHome(path, users, pets, currentUser, groups);
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
        List<Group> groups = new List<Group>();
        groups.Add(new Group("Default Group", users[0]));
        string path = "Home";
        User currentUser;

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

        bool logInOrSignIn = LogInOrSignIn();
        if (logInOrSignIn)
        {
            currentUser = SignIn(users.Count);
            if (currentUser != null)
            {
                users.Add(currentUser);
                Console.Clear();
                path = Home();
                pathHome(path, users, pets, currentUser, groups);
            }
        }
        else
        {
            currentUser = LogIn(users);
            if (currentUser != null)
            {
                Console.Clear();
                path = Home();
                pathHome(path, users, pets, currentUser, groups);
            }
        }
    }

}