using DomainModel.Entities;
using Dto.Response.Location;

namespace Dto.Response.Character
{
    public class CharacterGetAllResponseDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string species { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public int locationId { get; set; }
        public LocationGetByIdResponseDto location { get; set; } = null!;
        public string image { get; set; } = string.Empty;
        public ICollection<EpisodeCharacter> episodes { get; set; } = [];
        public string url { get; set; } = string.Empty;
        public string created { get; set; } = string.Empty;
    }
}
