using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Board
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Section>? Sections { get; set; } = [];
        public List<User>? Users { get; set; } = [];
    }
}