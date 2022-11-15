namespace KlinikaWeterynaryjna.Models
{
    public class AnimalsQuery
    {
        public string? SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
