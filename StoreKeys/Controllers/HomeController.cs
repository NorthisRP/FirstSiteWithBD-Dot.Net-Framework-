using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreKeys.Models;


namespace StoreKeys.Controllers
{
    public class HomeController : Controller
    {
        KeyContext keyContext = new KeyContext();

        
        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Key> keys = keyContext.Keys;
            ViewBag.Keys = keys;

            return View();
        }

        
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {

            if (keyContext.Users.Any(u => u.Email == user.Email))
            {
                return Redirect("/Home/Login");
            }
            else if (user.Password != "" && user.Name != "" && user.Surname != "" && user.Email != "")
            {
                keyContext.Users.Add(user);
                keyContext.SaveChangesAsync();
                return Redirect("/Home/Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Autorized"] != null)
            {
                return Redirect("/Home/Account");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            if (keyContext.Users.Any(u => u.Email == email && u.Password == password))
            {
                var User = keyContext.Users.Where(u => u.Email == email);
                Session["Autorized"] = true;
                Session["Password"] = password;
                Session["Id"] = User.ToList()[0].Id;
                Session["Email"] = User.ToList()[0].Email;
                Session["Name"] = User.ToList()[0].Name;
                Session["Surname"] = User.ToList()[0].Surname;
                return Redirect("/Home/Account");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Account() // параметр - id товара
        {
            if (Session["Autorized"] == null)
            {
                return Redirect("/Home/Login");
            }
            int userId = (int)Session["Id"];

            User user = new User();
            user.Id = (int)Session["Id"];
            user.Password = (string)Session["Password"];
            user.Email = (string)Session["Email"];
            user.Name = (string)Session["Name"];
            user.Surname = (string)Session["Surname"];
            ViewBag.User = user;

            var Carts = keyContext.Orders.Join(keyContext.Keys, o => o.KeyId, key => key.Id,
                (o, key) => new Cart()
                {
                    IdUser = o.UserId,
                    IdKey = key.Id,
                    Name = key.Name,
                    Price= key.Price,
                    Tag=key.Tag,
                    Img=key.Img
                });

            var cartOfUser = Carts.Where(ordr => ordr.IdUser == userId);
            var cart = cartOfUser.ToList();

            ViewBag.Cart = cart;

            return View(ViewBag);
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            if (Session["Autorized"] != null)
            {
                int userId = (int)Session["Id"];
                Order order = new Order();
                order.date = DateTime.Now;
                order.KeyId = id;
                order.UserId = userId;
                keyContext.Orders.Add(order);
                keyContext.SaveChanges();
                return Redirect("/Home/Account");
            }
            else
            {
                return Redirect("/Home/Login");
            }
        }
        [HttpGet]
        public ActionResult Quit()
        {
            Session.Clear();
            return Redirect("/Home/Index");
        }
    }
}