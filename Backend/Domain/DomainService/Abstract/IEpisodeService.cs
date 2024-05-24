using DomainModel.Entities;
using DomainService.Services;
using Dto.Request.Episode;

namespace DomainService.Abstract
{
    public interface IEpisodeService
    {
        Task<Episode> CreateAsync(Episode entity);
        Task<PagedList<Episode>> GetAllAsync(EpisodeParametersDto parametersDto);
        Task<Episode?> GetByIdAsync(int id);
        Task<Episode> UpdateAsync(Episode entity);
        Task DeleteAsync(Episode entity);
    }
}
