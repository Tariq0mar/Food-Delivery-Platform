using System.Data;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IOrderService
{
    void AddOrder(Order order);
    List<Order> GetNewOrders(int order);
}