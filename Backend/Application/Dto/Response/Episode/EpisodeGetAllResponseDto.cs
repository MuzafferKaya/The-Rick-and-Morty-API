using DomainModel.Entities;

namespace Dto.Response.Episode
{
    public class EpisodeGetAllResponseDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string airDate { get; set; } = string.Empty;
        public string episodeCode { get; set; } = string.Empty;
        public ICollection<EpisodeCharacter> characters { get; set; } = [];
        public string url { get; set; } = string.Empty;
        public string created { get; set; } = string.Empty;
    }
}
