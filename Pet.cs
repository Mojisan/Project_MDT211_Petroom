public class Pet
{
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