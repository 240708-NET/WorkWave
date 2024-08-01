namespace Models
{
    public class User
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Board> Boards { get; set; }
        public List<Card> Cards { get; set; }
    }
}