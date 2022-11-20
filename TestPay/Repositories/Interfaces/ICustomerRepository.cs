using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestPay.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<SelectListItem> GetAllCustomers();
    }
}
