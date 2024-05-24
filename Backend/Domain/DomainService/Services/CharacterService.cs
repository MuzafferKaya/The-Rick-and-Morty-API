using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstract;
using Dto.Request.Character;

namespace DomainService.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IRepository<Character> _repository;

        public CharacterService(IRepository<Character> repository)
        {
            this._repository = repository;
        }

        public async Task<Character> CreateAsync(Character entity)
        {
            entity.Created = DateTime.Now.ToString();
            await _repository.CreateAsync(entity);
            return entity;
        }

        public async Task<PagedList<Character>> GetAllAsync(CharacterParametersDto parametersDto)
        {
            return await PagedList<Character>.toPagedList(_repository.getSource(), parametersDto.PageNumber, parametersDto.pageSize);
        }

        public async Task<Character?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Character> UpdateAsync(Character entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Character entity)
        {
            await _repository.DeleteAsync(entity);
        }
    }
}
