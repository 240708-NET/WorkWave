namespace Models
{
    public class Board
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<User> Users { get; set; }
    }
}