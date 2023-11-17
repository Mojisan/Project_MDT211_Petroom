using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void OpenApp()
    {
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
        users.Add(new User(1, "Jiramet", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(2, "Yomu", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(3, "Akira", 19, "0610614617", "Image", "jib8147@gmail.com"));
        users.Add(new User(3, "jiramet", 18, "0610614617", "Image", "jib8147@gmail.com"));
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

    public static void SearchUI(List<User> users, List<Pet> pets)
    {
        Console.WriteLine("||=================Search=================||");
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

        }
        if (Search(keyword, users[users.Count - 1]) == null && check)
        {
            Console.WriteLine("||Not Found!!");
        }
        /* else if (Search(keyword, pets[pets.Count - 1]) < 0 && check) {
            Console.WriteLine("||Not Found!!");
        } */
        Console.WriteLine("||===============End of Search============||");
    }
    public static User Search(string keyword, User user)
    {
        if (user.Username.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            return user;
        }
        /* foreach (Pet pet in pets)
        {
            if (pet.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || pet.Specie.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || pet.Breed.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 && user.Username.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 )
            {
                return user;
            }
            else
            {
                return null;
            }
        } */

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

    public static void Main(string[] args)
    {
        List<User> users = AddUser();
        List<Pet> pets = AddPet();
        OpenApp();

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


        /* foreach (User user in users)
        {
            Profile(user);
        } */

        SearchUI(users, pets);
    }
}