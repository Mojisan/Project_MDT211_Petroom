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
    public static User[] AddUser()
    {
        User[] users = {
            new User(1, "Jiramet", 19, "0610614617", "Image", "jib8147@gmail.com"),
            new User(2, "Yomu", 19, "0610614617", "Image", "jib8147@gmail.com"),
            new User(3, "Akira", 19, "0610614617", "Image", "jib8147@gmail.com"),
        };
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

    public static void SearchUI(User[] users, List<Pet> pets)
    {
        Console.WriteLine("||=================Search=================||");
        Console.Write("||Keyword : ");
        string keyword = Console.ReadLine();
        Console.WriteLine("||----------------------------------------||");
        User Find = Search(keyword, users, pets);
        if (Find != null)
        {
            Profile(Find);
        }
        else
        {
            Console.WriteLine("||Not Found!!");
        }
    }

    public static User Search(string keyword, User[] users, List<Pet> pets)
    {
        foreach (User user in users)
        {
            if (user.Username.Contains(keyword))
            {
                return user;
            }
            else
            {
                foreach (Pet pet in pets)
                {
                    if (pet.Name.Contains(keyword) || pet.Specie.Contains(keyword) || pet.Breed.Contains(keyword))
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        return null;
    }

    public static void Main(string[] args)
    {
        User[] users = AddUser();
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