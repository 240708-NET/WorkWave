namespace Models
{
    public class Tag
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public List<Card>? Cards { get; set; }
    }
}