namespace Models
{
    public class Card
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Section Section { get; set; }
        public List<Tag> Tags { get; set; }
        public List<User> UsersAssigned { get; set; }
    }
}