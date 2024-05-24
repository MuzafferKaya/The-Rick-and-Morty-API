using AutoMapper;
using DomainModel.Entities;
using DomainService.Abstract;
using Dto.Request.Location;
using Dto.Response.Location;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationController(
            ILocationService locationService,
            IMapper mapper)
        {
            this._locationService = locationService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LocationCreateRequestDto requestDto)
        {
            var location = _mapper.Map<Location>(requestDto);
            var createdLocation = await _locationService.CreateAsync(location);
            return Created(string.Empty, _mapper.Map<LocationGetByIdResponseDto>(createdLocation));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] LocationParametersDto parametersDto)
        {
            var locations = await _locationService.GetAllAsync(parametersDto);
            var pagination = new
            {
                count = locations.TotalCount,
                pages = locations.PageSize,
                totalPages = locations.TotalPages,
                currentPage = locations.CurrentPage,
                next = locations.HasNext,
                prev = locations.HasPrevious,
            };
            return Ok(new { info = pagination, results = _mapper.Map<IEnumerable<LocationGetAllResponseDto>>(locations) });
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            return Ok(_mapper.Map<LocationGetByIdResponseDto>(location));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] LocationUpdateRequestDto requestDto)
        {
            var currentLocation = _mapper.Map<Location>(requestDto);
            var updatedLocation = await _locationService.UpdateAsync(currentLocation);
            return Ok(_mapper.Map<LocationGetByIdResponseDto>(updatedLocation));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var location = await _locationService.GetByIdAsync(id);
            await _locationService.DeleteAsync(location);
            return Ok();
        }
    }
}
