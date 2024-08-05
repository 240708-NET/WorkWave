namespace Models
{
    public class Section
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Board Board { get; set; }
        public List<Card> Cards { get; set; }
    }
}