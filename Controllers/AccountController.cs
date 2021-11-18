using Game2Play.DBModel;
using Game2Play.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Game2Play.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities objUserDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }

        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                if (!objUserDBEntities.Users.Any(m => m.Email == objUserModel.Email))
                {
                    User objUser = new DBModel.User
                    {
                        CreatedOn = DateTime.Now,
                        Email = objUserModel.Email,
                        FirstName = objUserModel.FirstName,
                        LastName = objUserModel.LastName,
                        Password = objUserModel.Password
                    };
                    objUserDBEntities.Users.Add(objUser);
                    objUserDBEntities.SaveChanges();
                    objUserModel = new UserModel();
                    objUserModel.SuccessMessage = "User is Successfully Registered";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email is already registered!");
                    return View();
                }
            }
            return View();
        }

        public ActionResult Login()
        {
            LoginModel objloginModel = new LoginModel();
            return View(objloginModel);
        }
        
        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if(ModelState.IsValid)
            {
                if (objUserDBEntities.Users.Where(m => m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Email and Password do not match");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}