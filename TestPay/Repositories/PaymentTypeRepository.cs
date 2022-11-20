using Microsoft.AspNetCore.Mvc.Rendering;
using TestPay.Data;
using TestPay.Repositories.Interfaces;

namespace TestPay.Repositories
{
    public class PaymentTypeRepository: IPaymentTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public PaymentTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (
                                    from obj in _context.PaymentTypes
                                    select new SelectListItem
                                    {
                                        Text = obj.PaymentTypeName,
                                        Value = obj.PaymentTypeId.ToString(),
                                        Selected = true
                                    }
                                ).ToList();

            return objSelectListItems;
        }
    }
}
