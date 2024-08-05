namespace Models
{
    public class Card
    {
        public int ID { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required Section Section { get; set; }
        public List<Tag>? Tags { get; set; }
        public required List<User> UsersAssigned { get; set; }
    }
}