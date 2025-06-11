using ItlaincenstmentApp.Core.Aplicationn.Dtos.UserDtos;
using ItlaincenstmentApp.Core.Aplicationn.Interfaces;
using ItlaincenstmentApp.Core.Domain.Entities;
using ItlaincenstmentApp.Core.Domain.Interfaces;
using ItlaincenstmentApp.Core.Domain.Shere;
using ItlaincenstmentApp.Core.Domain.ValidationEntities;

namespace ItlaincenstmentApp.Core.Aplicationn.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<OperationResult<UserDto>> AddAsync(UserDto dto)
        {
            if (dto == null) return OperationResult<UserDto>.Fail("Dto is null here");

            User entity = new() 
            {
                Id = 0,
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                Phone = dto.Phone,
                ProfileImage = dto.ProfileImage,
            };

            var result = await _repository.AddAsync(entity);

            if (!result.IsSuccess)
                return OperationResult<UserDto>.Fail(result.Message);

            return OperationResult<UserDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<UserDto>> UbdateAsync(UserDto dto)
        {
            if (dto == null) return OperationResult<UserDto>.Fail("Dto is null here");

            User user = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role,
                Phone = dto.Phone,
                ProfileImage = dto.ProfileImage,
            };

            var result = await _repository.UpdateAsync(dto.Id, user);

            if (!result.IsSuccess)
                return OperationResult<UserDto>.Fail(result.Message);

            return OperationResult<UserDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<UserDto>> DeleteAsync(int id)
        {
            var IsSuccess = GenericValidId.ValidId(id);
            if (!IsSuccess.IsSuccess)
                return OperationResult<UserDto>.Fail(IsSuccess.Message);

            var result = await _repository.Remove(id);

            if (!result.IsSuccess)
                return OperationResult<UserDto>.Fail(result.Message);

            UserDto dto = new()
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                LastName = result.Value.LastName,
                Email = result.Value.Email,
                Password = result.Value.Password,
                Role = result.Value.Role,
                Phone = result.Value.Phone,
                ProfileImage = result.Value.ProfileImage,
            };

            return OperationResult<UserDto>.Success(dto, result.Message);
        }
        public async Task<OperationResult<UserDto>> GetByIdAsync(int id)
        {
            var IsSuccess = GenericValidId.ValidId(id);
            if (!IsSuccess.IsSuccess)
                return OperationResult<UserDto>.Fail(IsSuccess.Message);

            var result = await _repository.GetByIdAsync(id);

            if (!result.IsSuccess)
                return OperationResult<UserDto>.Fail(result.Message);

            UserDto dto = new()
            {
                Id = result.Value.Id,
                Name = result.Value.Name,
                LastName = result.Value.LastName,
                Email = result.Value.Email,
                Password = "",
                Role = result.Value.Role,
                Phone = result.Value.Phone,
                ProfileImage = result.Value.ProfileImage,
            };

            return OperationResult<UserDto>.Success(dto, result.Message);
        }
        public Task<OperationResult<ICollection<UserDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<ICollection<UserDto>>> GetAllWithAsset()
        {
            throw new NotImplementedException();
        }
    }
}
