using AutoMapper;
using DomainModel.Entities;
using Dto.Request.Character;
using Dto.Request.Episode;
using Dto.Request.Location;
using Dto.Response.Character;
using Dto.Response.Episode;
using Dto.Response.Location;

namespace Dto
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EpisodeCreateRequestDto, Episode>();
            CreateMap<EpisodeUpdateRequestDto, Episode>();
            CreateMap<Episode, EpisodeGetAllResponseDto>();
            CreateMap<Episode, EpisodeGetByIdResponseDto>();

            CreateMap<CharacterCreateRequestDto, Character>();
            CreateMap<CharacterUpdateRequestDto, Character>();
            CreateMap<Character, CharacterGetAllResponseDto>();
            CreateMap<Character, CharacterGetByIdResponseDto>();

            CreateMap<LocationCreateRequestDto, Location>();
            CreateMap<LocationUpdateRequestDto, Location>();
            CreateMap<Location, LocationGetAllResponseDto>();
            CreateMap<Location, LocationGetByIdResponseDto>();
        }
    }
}
