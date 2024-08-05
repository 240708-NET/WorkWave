namespace Models
{
    public class Board
    {
        public int ID { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required List<User> Users { get; set; }
    }
}