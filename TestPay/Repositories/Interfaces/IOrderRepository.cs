using TestPay.ViewModels;

namespace TestPay.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        bool AddOrder(OrderViewModel orderViewModel);
    }
}
