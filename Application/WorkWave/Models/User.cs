namespace Models
{
    public class User
    {
        public int ID { get; set; }
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public List<Board>? Boards { get; set; }
        public List<Card>? Cards { get; set; }
    }
}