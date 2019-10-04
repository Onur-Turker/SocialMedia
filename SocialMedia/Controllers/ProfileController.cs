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
    public class ProfileController : Controller
    {
        IUserRepository _urep;
        public ProfileController(IUserRepository urep)
        {
            _urep = urep;
        }
        
        public ActionResult Index(int id)
        {
      
            User u = _urep.Find(id);
            UserViewModel uvm = new UserViewModel();
            uvm.Id = u.Id;
            uvm.Name = u.Name;
            uvm.Surname = u.Surname;
            uvm.Email = u.Email;
            uvm.Gender = u.Gender;
            uvm.Password = u.Password;
            uvm.Coutry = u.Coutry;
            uvm.City = u.City;
            uvm.BirthDay = u.BirthDay;
            uvm.Province = u.Province;
            uvm.ProfilePhoto = u.ProfilePhoto;
            return View(uvm);
        }

        [HttpPost]
        public ActionResult ProfileUpdate(UserViewModel usr)
        {

            int id =Convert.ToInt32(Session["Id"]);
            User u = _urep.Find(id);


            string fileName = Server.MapPath("../Images/" + usr.Name + "_" + id + ".jpg");
            var file = Request.Files["ProfilePhoto"];
            file.SaveAs(fileName);

            u.ProfilePhoto = usr.Name + "_" + id + ".jpg";

            u.Name = usr.Name;
            u.Surname = usr.Surname;
            u.Email = usr.Email;
            u.Password = usr.Password;
            u.Coutry = usr.Coutry;
            u.City = usr.City;
            u.Gender = usr.Gender;
            u.Province = usr.Province;
            _urep.Update(u);
           

            return RedirectToAction("Index");
        }
    }
}