namespace KlinikaWeterynaryjna.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Weight { get; set; }
        public DateTime FirstVisit { get; set; }
        public DateTime LastVisit { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
    }
}
