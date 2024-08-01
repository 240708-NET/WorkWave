namespace Models
{
    public class Section
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BoardID { get; set; }
        public List<Card> Cards { get; set; }
    }
}