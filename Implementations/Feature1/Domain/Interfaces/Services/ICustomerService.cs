using Application.DTOs.CustomerModels;

namespace Domain.Interfaces.Services;

public interface ICustomerService
{
    public Task<Guid> RegisterAsync(RegisterDto dto);
    public Task<LoginResultDto?> LoginAsync(LoginDto dto);
}