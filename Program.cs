using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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
    public static List<User> AddUser()
    {
        List<User> users = new List<User>();
        users.Add(new User(1, "Jiramet", "asdfghjkl", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(2, "Yomu", "qwerty", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(3, "Akira", "zxcvbnm", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(3, "jiramet", "qazwsx", 18, "0610614617", "Image", "jib8147@gmail.com"));
        return users;
    }

    public static List<Pet> AddPet()
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
        User userLoginComplete = CheckLogIn(usernameLogIn, passwordLogIn, users);
        if (userLoginComplete != null)
        {
            Console.WriteLine("||=============Log In Complete============||");
            return userLoginComplete;
        }
        else
        {
            Console.WriteLine("||=============Worng Password=============||");
            return null;
        }
    }

    public static User CheckLogIn(string username, string password, List<User> users)
    {
        foreach (User user in users)
        {
            if ((user.Username == username || user.Email == username) && user.Password == password)
            {
                return user;
            }
        }
        return null;
    }

    public static void SearchUI(List<User> users, List<Pet> pets)
    {
        Console.WriteLine("||=================Search=================||");
        /* Console.WriteLine("User: {0}", currentUser); */
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
                break;
            case "Profile":
                Console.Clear();
                Profile(currentUser);
                do
                {
                    key = Console.ReadKey();
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
        List<User> users = AddUser();
        List<Pet> pets = AddPet();
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
            }
        }
        else
        {
            currentUser = LogIn(users);
            if (currentUser != null)
            {
                Console.Clear();
                path = Home();
            }
        }
        pathHome(path, users, pets, currentUser);
    }

}