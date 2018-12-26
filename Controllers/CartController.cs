
using System.Linq;
using System.Web.Mvc;
using TouristAgency.Models;
namespace TouristAgency.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db;
        public CartController()
        {
            db=new ApplicationDbContext();
        }

        public RedirectToRouteResult AddToCart(int id, string returnUrl)
        {
            Tour tour = db.Tours
                .FirstOrDefault(g => g.Id == id);

            if (tour != null)
            {
                GetCart().AddItem(tour, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int id, string returnUrl)
        {
            Tour tour = db.Tours
                 .FirstOrDefault(g => g.Id == id);

            if (tour != null)
            {
                GetCart().RemoveLine(tour);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}
