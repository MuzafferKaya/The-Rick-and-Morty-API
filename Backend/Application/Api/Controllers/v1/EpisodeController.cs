using AutoMapper;
using DomainModel.Entities;
using DomainService.Abstract;
using Dto.Request.Episode;
using Dto.Response.Episode;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/episode")]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;
        private readonly IMapper _mapper;

        public EpisodeController(
            IEpisodeService episodeService,
            IMapper mapper)
        {
            this._episodeService = episodeService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EpisodeCreateRequestDto requestDto)
        {
            var episode = _mapper.Map<Episode>(requestDto);
            var createdEpisode = await _episodeService.CreateAsync(episode);
            return Created(string.Empty, _mapper.Map<EpisodeGetByIdResponseDto>(createdEpisode));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] EpisodeParametersDto parametersDto)
        {
            var episodes = await _episodeService.GetAllAsync(parametersDto);
            var pagination = new
            {
                count = episodes.TotalCount,
                pages = episodes.PageSize,
                totalPages = episodes.TotalPages,
                currentPage = episodes.CurrentPage,
                next = episodes.HasNext,
                prev = episodes.HasPrevious,
            };
            return Ok(new { info = pagination, results = _mapper.Map<IEnumerable<EpisodeGetAllResponseDto>>(episodes) });
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var episode = await _episodeService.GetByIdAsync(id);
            return Ok(_mapper.Map<EpisodeGetByIdResponseDto>(episode));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] EpisodeUpdateRequestDto requestDto)
        {
            var currentEpisode = _mapper.Map<Episode>(requestDto);
            var updatedEpisode = await _episodeService.UpdateAsync(currentEpisode);
            return Ok(_mapper.Map<EpisodeGetByIdResponseDto>(updatedEpisode));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var episode = await _episodeService.GetByIdAsync(id);
            await _episodeService.DeleteAsync(episode);
            return Ok();
        }
    }
}
