using Microsoft.AspNetCore.Mvc.Rendering;
using TestPay.Data;
using TestPay.Repositories.Interfaces;

namespace TestPay.Repositories
{
    public class ItemRepository : IitemRepository
    {
        private readonly ApplicationDbContext _context;
      
        public ItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (
                                    from obj in _context.Items
                                    select new SelectListItem
                                    {
                                        Text = obj.ItemName,
                                        Value = obj.ItemId.ToString(),
                                        Selected = true
                                    }
                                ).ToList();

            return objSelectListItems;
        }
    }
}
