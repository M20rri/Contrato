using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contrato.Models;
using Contrato.Service;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Contrato.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPayMob _payMob;

        public HomeController(IPayMob payMob)
        {
            _payMob = payMob;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(Product model)
        {
            #region Step 1

            var GToken = await _payMob.GenerateToken();

            #endregion

            #region Step 2

            OrderRegistryReqVM orderRegistryReqVM = new OrderRegistryReqVM
            {
                amount_cents = model.Cost,
                auth_token = GToken.token,
                currency = "EGP",
                items = new List<Item>
                {
                    new Item { name = model.Name , description = model.Description , amount_cents = model.Cost , quantity = model.Quantity }
                }
            };

            var OrderRegistery = await _payMob.ProductRegistration(orderRegistryReqVM);

            #endregion


            #region Step 3

            PaymentKeyReqVM paymentKeyReqVM = new PaymentKeyReqVM
            {
                auth_token = GToken.token,
                amount_cents = model.Cost,
                expiration = 3600,
                order_id = OrderRegistery.id.ToString(),
                billing_data = new BillingData
                {
                    apartment = "803",
                    email = "m.eltorri@boutiqaat.com",
                    floor = "42",
                    first_name = "Mahmoud",
                    street = "Ethan Land",
                    building = "8028",
                    phone_number = "+201159313034",
                    shipping_method = "PKG",
                    postal_code = "01898",
                    city = "Jaskolskiburgh",
                    country = "CR",
                    last_name = "Torri",
                    state = "Utah"
                },
                currency = "EGP"
            };

            var PKey = await _payMob.PaymentKey(paymentKeyReqVM);

            #endregion


            return RedirectPermanent($"https://accept.paymob.com/api/acceptance/iframes/372580?payment_token={PKey.token}");
        }


        public IActionResult Callback()
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
