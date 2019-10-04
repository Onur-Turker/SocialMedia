using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Newtonsoft.Json;
using SocialMedia.CustomActionFilter;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    [CheckLogin]
    public class MyProfileController : Controller
    {
        IUserRepository _urep;
        ISharingRepository _srep;
        ICommentRepository _crep;
        public MyProfileController(IUserRepository urep, ISharingRepository srep, ICommentRepository crep)
        {
            _urep = urep;
            _srep = srep;
            _crep = crep;
        }


        public ActionResult Index()
        {
            int id =Convert.ToInt32(Session["Id"]);
            List<Sharing> slist = _srep.MyProfileList(id);
            string str = JsonConvert.SerializeObject(slist, new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            string str3 = JsonConvert.SerializeObject(_urep.List(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<UserViewModel> ulist = JsonConvert.DeserializeObject<List<UserViewModel>>(str3);

            ViewBag.usrlist = ulist;

            List<SharingViewModel> svmlist = JsonConvert.DeserializeObject<List<SharingViewModel>>(str);
            return View(svmlist);
        }

        public ActionResult UserProfile(int id)
        {
            User user = _urep.Find(id);


            List<Sharing> slist = user.Sharings;
            string str = JsonConvert.SerializeObject(slist, new JsonSerializerSettings
            {
             ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            List<SharingViewModel> svmlist = JsonConvert.DeserializeObject<List<SharingViewModel>>(str);

            string str3 = JsonConvert.SerializeObject(user, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            UserViewModel u = JsonConvert.DeserializeObject<UserViewModel>(str3);

            ViewBag.usrlist = u;

            UserProfileViewModel upvm = new UserProfileViewModel() {
                Sharings = svmlist,
                User = u
            };

            
            return View(upvm);
        }
    }
}