using AutoMapper;
using DomainModel.Entities;
using DomainService.Abstract;
using Dto.Request.Character;
using Dto.Response.Character;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(
            ICharacterService characterService,
            IMapper mapper)
        {
            this._characterService = characterService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CharacterCreateRequestDto requestDto)
        {
            var character = _mapper.Map<Character>(requestDto);
            var createdCharacter = await _characterService.CreateAsync(character);
            return Created(string.Empty, _mapper.Map<CharacterGetByIdResponseDto>(createdCharacter));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] CharacterParametersDto parametersDto)
        {
            var characters = await _characterService.GetAllAsync(parametersDto);
            var pagination = new
            {
                count = characters.TotalCount,
                pages = characters.PageSize,
                totalPages = characters.TotalPages,
                currentPage = characters.CurrentPage,
                next = characters.HasNext,
                prev = characters.HasPrevious,
            };
            return Ok(new { info = pagination, results = _mapper.Map<IEnumerable<CharacterGetAllResponseDto>>(characters) });
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            return Ok(_mapper.Map<CharacterGetByIdResponseDto>(character));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CharacterUpdateRequestDto requestDto)
        {
            var currentCharacter = _mapper.Map<Character>(requestDto);
            var updatedCharacter = await _characterService.UpdateAsync(currentCharacter);
            return Ok(_mapper.Map<CharacterGetByIdResponseDto>(updatedCharacter));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var character = await _characterService.GetByIdAsync(id);
            await _characterService.DeleteAsync(character);
            return Ok();
        }
    }
}
