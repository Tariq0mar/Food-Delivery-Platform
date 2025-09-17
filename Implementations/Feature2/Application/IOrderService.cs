namespace Application;

public interface IOrderService
{
    Task<string?> GetOrderStatus(int orderId);
}