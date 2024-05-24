using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModel.Entities
{
    [Table("EpisodeCharacters")]
    public class EpisodeCharacter
    {
        public int EpisodeId { get; set; }
        public Episode? Episode { get; set; } = null;
        public int CharacterId { get; set; }
        public Character? Character { get; set; } = null;
    }
}
