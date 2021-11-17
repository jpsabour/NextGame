using Game2Play.DBModel;
using Game2Play.Models;
using System;
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
                return View();
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}