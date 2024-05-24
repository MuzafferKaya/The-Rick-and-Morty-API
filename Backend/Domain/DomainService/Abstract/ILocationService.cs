using DomainModel.Entities;
using DomainService.Services;
using Dto.Request.Location;

namespace DomainService.Abstract
{
    public interface ILocationService
    {
        Task<Location> CreateAsync(Location entity);
        Task<PagedList<Location>> GetAllAsync(LocationParametersDto parametersDto);
        Task<Location?> GetByIdAsync(int id);
        Task<Location> UpdateAsync(Location entity);
        Task DeleteAsync(Location entity);
    }
}
