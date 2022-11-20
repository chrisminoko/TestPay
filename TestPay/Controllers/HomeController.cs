using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TestPay.Data;
using TestPay.Models;
using TestPay.Repositories;
using TestPay.Repositories.Interfaces;
using TestPay.ViewModels;

namespace TestPay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly ICustomerRepository _customerRepository; 
        private readonly IitemRepository _ItemRepository;
        private readonly IPaymentTypeRepository _PaymentTypeRepository;
       private IOrderRepository _OrderRepository;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, ICustomerRepository customerRepository, IitemRepository itemRepository, IPaymentTypeRepository paymentTypeRepository, IOrderRepository orderRepository)
        {
            _logger = logger;
            _context = context;
            _customerRepository = customerRepository;
            _ItemRepository = itemRepository;
            _PaymentTypeRepository = paymentTypeRepository;
            _OrderRepository = orderRepository;
        }

        public IActionResult Index()
        {
         
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>(
                    _customerRepository.GetAllCustomers(), _ItemRepository.GetAllItems(), _PaymentTypeRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }


        [HttpGet]

        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = _context.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
           
            bool isStatus = _OrderRepository.AddOrder(objOrderViewModel);
            string SuccessMessage = String.Empty;

            if (isStatus)
            {
                SuccessMessage = "Your Order Has Been Successfully Placed.";
            }
            else
            {
                SuccessMessage = "There Is Some Issue While Placing Order.";
            }
            return Json(SuccessMessage);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}