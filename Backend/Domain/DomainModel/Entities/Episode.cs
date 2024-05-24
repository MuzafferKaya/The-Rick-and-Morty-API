using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("Episodes")]
    public class Episode : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string AirDate { get; set; } = string.Empty;
        public string EpisodeCode { get; set; } = string.Empty;
        public ICollection<EpisodeCharacter> Characters { get; set; } = [];
        public string Url { get; set; } = string.Empty;
    }
}
