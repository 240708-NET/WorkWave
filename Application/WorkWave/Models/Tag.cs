namespace Models
{
    public class Tag
    {
        public int ID { get; set; }
        public required string Description { get; set; }
        public required string Color { get; set; }
        public List<Card>? Cards { get; set; }
    }
}