using ItlaincenstmentApp.Core.Aplicationn.Dtos.AssetDtos;
using ItlaincenstmentApp.Core.Domain.Shere;

namespace ItlaincenstmentApp.Core.Aplicationn.Interfaces.Common
{
    public interface IGenericServices<DTO> where DTO : class
    {
        Task<OperationResult<DTO>> AddAsync(DTO dto);
        Task<OperationResult<DTO>> DeleteAsync(int id);
        Task<OperationResult<ICollection<DTO>>> GetAll();
        Task<OperationResult<ICollection<DTO>>> GetAllWithAsset();
        Task<OperationResult<DTO>> GetByIdAsync(int id);
        Task<OperationResult<DTO>> UbdateAsync(DTO dto);
    }
}
