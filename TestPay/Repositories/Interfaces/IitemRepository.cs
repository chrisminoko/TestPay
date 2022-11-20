using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestPay.Repositories.Interfaces
{
    public interface IitemRepository
    {
        IEnumerable<SelectListItem> GetAllItems();
    }
}
