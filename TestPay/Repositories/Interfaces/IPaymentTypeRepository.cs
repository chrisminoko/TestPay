using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestPay.Repositories.Interfaces
{
    public interface IPaymentTypeRepository
    {
        IEnumerable<SelectListItem> GetAllPaymentType();
    }
}
