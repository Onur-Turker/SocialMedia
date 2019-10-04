using DataAccessLayer;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repositories;
using Newtonsoft.Json;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    public class LoginController : Controller
    {
        IUserRepository _urep;

        public LoginController(IUserRepository urep)
        {
            _urep = urep;
        }

        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel uvm)
        {
            string str = JsonConvert.SerializeObject(uvm);
            User u = JsonConvert.DeserializeObject<User>(str);
            _urep.Add(u);
            string Email = uvm.Email;
            string Password = uvm.Password;

            List<User> ulist = _urep.LoginControl(Email, Password);
                Session["User"] = ulist[0];
                Session["Id"] = ulist[0].Id;
                Session["Name"] = ulist[0].Name;
                Session["Surname"] = ulist[0].Surname;
                Session["Coutry"] = ulist[0].Coutry;
                Session["City"] = ulist[0].City;
                Session["ProfilePhoto"] = ulist[0].ProfilePhoto;
            return RedirectToAction("Index", "HomePage");
        }

        public ActionResult Login(string Email, string Password)
        {
           List<User> ulist= _urep.LoginControl(Email,Password);
            if (ulist.Count>0)
            {
                Session["User"] = ulist[0];
                Session["Id"] = ulist[0].Id;
                Session["Name"] = ulist[0].Name;
                Session["Surname"] = ulist[0].Surname;
                Session["Coutry"] = ulist[0].Coutry;
                Session["City"] = ulist[0].City;
                Session["ProfilePhoto"] = ulist[0].ProfilePhoto;
                return RedirectToAction("Index","HomePage");
            }
            else
            {
                return View("Index");
            }
            
        }
    }
}