using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("Locations")]
    public class Location : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Dimension { get; set; } = string.Empty;
        public ICollection<Character> Residents { get; set; } = [];
        public string Url { get; set; } = string.Empty;
    }
}
