public class User
{
    /* private int idUser;
    private string name;
    private int age;
    private string number;
    private string imageUser;
    private string email;
    private List<Pet> idPets;

    public User(
        int idUser,
        string name,
        int age,
        string number,
        string imageUser,
        string email,
        List<Pet> idPets
        )
    {
        this.idUser = idUser;
        this.name = name;
        this.age = age;
        this.number = number;
        this.imageUser = imageUser;
        this.email = email;
        this.idPets = idPets;
    }

    public int GetIdUser()
    {
        return idUser;
    }
    public string GetName()
    {
        return name;
    }
    public int GetAge()
    {
        return age;
    }
    public string GetNumber()
    {
        return number;
    }
    public string GetImageUser()
    {
        return imageUser;
    }
    public string GetEmail()
    {
        return email;
    }
    public List<Pet> GetIdPet()
    {
        return idPets;
    }

    public void AddPetInUser(List<int> idPets)
    {
        this.idPets = idPets;
    } */

    public int UserId { get; set; }
    public string Username { get; set; }
    public int Age { get; set; }
    public string Number { get; set; }
    public string ImageUser { get; set; }
    public string Email { get; set; }
    public List<Pet> Pets;

    public User(
        int UserId,
        string Username,
        int Age,
        string Number,
        string ImageUser,
        string Email
        )
    {
        this.UserId = UserId;
        this.Username = Username;
        this.Age = Age;
        this.Number = Number;
        this.ImageUser = ImageUser;
        this.Email = Email;
        this.Pets = new List<Pet>();
    }

    public void AddPets(Pet pet)
    {
        Pets.Add(pet);
    }
}



/* string[] options = { "Option 1", "Option 2", "Option 3" };
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

                Console.WriteLine(options[i]);

                Console.ResetColor();
            }

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    selectedIndex = (selectedIndex - 1 + options.Length) % options.Length;
                    break;

                case ConsoleKey.RightArrow:
                    selectedIndex = (selectedIndex + 1) % options.Length;
                    break;
            }

        } while (key.Key != ConsoleKey.Enter);

        Console.Clear();
        Console.WriteLine($"You selected: {options[selectedIndex]}");*/