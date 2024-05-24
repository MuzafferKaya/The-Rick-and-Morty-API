using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstract;
using Dto.Request.Location;

namespace DomainService.Services
{
    public class LocationService : ILocationService
    {
        private readonly IRepository<Location> _repository;

        public LocationService(IRepository<Location> repository)
        {
            this._repository = repository;
        }

        public async Task<Location> CreateAsync(Location entity)
        {
            entity.Created = DateTime.Now.ToString();
            await _repository.CreateAsync(entity);
            return entity;
        }

        public async Task<PagedList<Location>> GetAllAsync(LocationParametersDto parametersDto)
        {
            return await PagedList<Location>.toPagedList(_repository.getSource(), parametersDto.PageNumber, parametersDto.pageSize);
        }

        public async Task<Location?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Location> UpdateAsync(Location entity)
        {
            await _repository.UpdateAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Location entity)
        {
            await _repository.DeleteAsync(entity);
        }
    }
}
