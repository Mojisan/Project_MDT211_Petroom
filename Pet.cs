public class Pet
{
    /* private int idPet;
    private int idUser;
    private string name;
    private int age;
    private string specie;
    private string breed;
    private string image_pet;
    private string status;
    private string m_history;
    private string trait;
    private string description;

    public Pet(
        int idPet,
        int idUser,
        string name,
        int age,
        string specie,
        string breed,
        string image_pet,
        string status,
        string m_history,
        string trait,
        string description
    )
    {
        this.idPet = idPet;
        this.idUser = idUser;
        this.name = name;
        this.age = age;
        this.specie = specie;
        this.breed = breed;
        this.image_pet = image_pet;
        this.status = status;
        this.m_history = m_history;
        this.trait = trait;
        this.description = description;
    }

    public int GetIdPet() {
        return idPet;
    }

    public int GetIdUser() {
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
    public string GetSpecie()
    {
        return specie;
    }
    public string GetBreed()
    {
        return breed;
    }
    public string GetImage_Pet()
    {
        return image_pet;
    }
    public string GetStatus()
    {
        return status;
    }
    public string GetM_history()
    {
        return m_history;
    }
    public string GetTrait()
    {
        return trait;
    }
    public string GetDescription()
    {
        return description;
    } */

    public int PetId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Age { get; set; }
    public string Specie { get; set; }
    public string Breed { get; set; }
    public string ImagePet { get; set; }
    public string Sex { get; set; }
    public string Status { get; set; }
    public string MHistory { get; set; }
    public string Trait { get; set; }
    public string Description { get; set; }

    public Pet(
        int PetId,
        int UserId,
        string Name,
        string Age,
        string Specie,
        string Breed,
        string ImagePet,
        string Sex,
        string Status,
        string MHistory,
        string Trait,
        string Description
    )
    {
        this.PetId = PetId;
        this.UserId = UserId;
        this.Name = Name;
        this.Age = Age;
        this.Specie = Specie;
        this.Breed = Breed;
        this.ImagePet = ImagePet;
        this.Sex = Sex;
        this.Status = Status;
        this.MHistory = MHistory;
        this.Trait = Trait;
        this.Description = Description;
    }
}