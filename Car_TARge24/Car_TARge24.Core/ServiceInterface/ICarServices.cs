using Car_TARge24.Core.Domain;
using Car_TARge24.Core.Dto;

namespace Car_TARge24.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Cars> Create(CarDto dto);
        Task<Cars> DetailAsync(Guid id);
        Task<Cars> Delete(Guid id);
        Task<Cars> Update(CarDto dto);
    }
}