using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstract;
using Dto.Request.Episode;

namespace DomainService.Services
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IRepository<Episode> _repository;

        public EpisodeService(IRepository<Episode> repository)
        {
            this._repository = repository;
        }

        public async Task<Episode> CreateAsync(Episode entity)
        {
            entity.Created = DateTime.Now.ToString();
            await _repository.CreateAsync(entity);
            return entity;
        }

        public async Task<PagedList<Episode>> GetAllAsync(EpisodeParametersDto parametersDto)
        {
            return await PagedList<Episode>.toPagedList(_repository.getSource(), parametersDto.PageNumber, parametersDto.pageSize);
        }

        public async Task<Episode?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Episode> UpdateAsync(Episode entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Episode entity)
        {
            await _repository.DeleteAsync(entity);
        }
    }
}
