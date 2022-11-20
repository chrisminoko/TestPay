using TestPay.Data;
using TestPay.Models;
using TestPay.Repositories.Interfaces;
using TestPay.ViewModels;

namespace TestPay.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _context;
      
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AddOrder(OrderViewModel orderViewModel)
        {
            try
            {
                Order objOrder = new Order()
                {
                    CustomerId = orderViewModel.CustomerId,
                    FinalTotal = orderViewModel.FinalTotal,
                    OrderDate = orderViewModel.OrderDate,
                    OrderNumber = String.Format("{0:ddmmyyyyhhmmss}", DateTime.Now),
                    PaymentTypeId = orderViewModel.PaymentTypeId,
                };
                _context.Orders.Add(objOrder);
                _context.SaveChanges();

                foreach (var item in orderViewModel.listOrderDetailViewModel)
                {
                    var objOrderDetails = new OrderDetail()
                    {
                        Discount = item.Discount,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity,
                        OrderId = objOrder.OrderId,
                        Total = item.Total,
                        UnitPrice = item.UnitPrice
                    };
                    _context.OrderDetails.Add(objOrderDetails);
                    _context.SaveChanges();

                    Transaction objTransaction = new Transaction()
                    {
                        ItemId = item.ItemId,
                        Quantity = (-1) * item.Quantity,
                        TranactionDate = orderViewModel.OrderDate,
                        TypeId = 2
                    };
                    _context.Transactions.Add(objTransaction);
                    _context.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
