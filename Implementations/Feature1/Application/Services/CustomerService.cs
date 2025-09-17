using Application.DTOs.CustomerModels;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<Guid> RegisterAsync(RegisterDto dto)
    {
        var existing = await _customerRepository.GetByEmailAsync(dto.Email);
        if (existing is not null)
            throw new InvalidOperationException("Email already registered");

        var customer = _mapper.Map<Customer>(dto);

        await _customerRepository.AddAsync(customer);
        return customer.Id;
    }

    public async Task<LoginResultDto?> LoginAsync(LoginDto dto)
    {
        var customer = await _customerRepository.GetByEmailAsync(dto.Email);

        if (customer is null)
            throw new Exception("Email was not registered");

        var hash = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(dto.Password));
        if (customer.PasswordHash != hash)
            throw new Exception("incorrect password");

        
        var token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        return new LoginResultDto(customer.Id, customer.Email, token);
    }
}