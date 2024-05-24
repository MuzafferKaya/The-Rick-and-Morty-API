using Dto.Response.Character;

namespace Dto.Response.Location
{
    public class LocationGetByIdResponseDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public string dimension { get; set; } = string.Empty;
        public ICollection<CharacterGetAllResponseDto> Residents { get; set; } = [];
        public string url { get; set; } = string.Empty;
        public string created { get; set; } = string.Empty;
    }
}
