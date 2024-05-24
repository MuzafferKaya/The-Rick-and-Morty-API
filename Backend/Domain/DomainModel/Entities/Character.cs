using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("Characters")]
    public class Character : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public string Image { get; set; } = string.Empty;
        public ICollection<EpisodeCharacter> Episodes { get; set; } = [];
        public string Url { get; set; } = string.Empty;
    }
}
