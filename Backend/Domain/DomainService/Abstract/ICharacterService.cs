using DomainModel.Entities;
using DomainService.Services;
using Dto.Request.Character;

namespace DomainService.Abstract
{
    public interface ICharacterService
    {
        Task<Character> CreateAsync(Character entity);
        Task<PagedList<Character>> GetAllAsync(CharacterParametersDto parametersDto);
        Task<Character?> GetByIdAsync(int id);
        Task<Character> UpdateAsync(Character entity);
        Task DeleteAsync(Character entity);
    }
}
