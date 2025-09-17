namespace Application.DTOs.CustomerModels;

public record LoginResultDto(Guid CustomerId, string Email, string Token);