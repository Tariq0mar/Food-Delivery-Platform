using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface ILocationService
{
    void UpdateDriverLocation(DriverLocation location);
    DriverLocation? GetLocationByOrderId(int orderId);
}