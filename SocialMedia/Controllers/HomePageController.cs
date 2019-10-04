using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repositories;
using Newtonsoft.Json;
using SocialMedia.CustomActionFilter;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    [CheckLogin]
    public class HomePageController : Controller
    {
        ISharingRepository _srep;
        IUserRepository _urep;
        ICommentRepository _crep;
        IFriendshipRequestRepository _fsrep;
        public HomePageController(IUserRepository urep, ISharingRepository srep, ICommentRepository crep, IFriendshipRequestRepository fsrep)
        {
            _srep = srep;
            _urep = urep;
            _crep = crep;
            _fsrep = fsrep;
        }

        public ActionResult Index()
        {
            List<Sharing> slist = _srep.ListHomePage();
            string str = JsonConvert.SerializeObject(slist, new JsonSerializerSettings {

                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<SharingViewModel> svmlist = JsonConvert.DeserializeObject<List<SharingViewModel>>(str);

            int id = Convert.ToInt32(Session["Id"]);
            string str2 = JsonConvert.SerializeObject(_fsrep.FSRList(id), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<FriendshipRequestViewModel> result = JsonConvert.DeserializeObject<List<FriendshipRequestViewModel>>(str2);

            Session["FSR"] = result;

            string str4 = JsonConvert.SerializeObject(_fsrep.Friends(id), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<FriendshipRequestViewModel> friends = JsonConvert.DeserializeObject<List<FriendshipRequestViewModel>>(str2);

            Session["friends"] = friends;

            string str3 = JsonConvert.SerializeObject(_urep.List(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<UserViewModel> ulist = JsonConvert.DeserializeObject<List<UserViewModel>>(str3);

            ViewBag.usrlist = ulist;

            return View(svmlist);
        }

        [HttpPost]
        public ActionResult AddSharing(SharingViewModel svm)
        {
            int id = Convert.ToInt32(Session["Id"]);
            User u = _urep.Find(id);

            svm.SharingDate = DateTime.Now;

            string str = JsonConvert.SerializeObject(svm);
            Sharing s = JsonConvert.DeserializeObject<Sharing>(str);
            s.User = u;
            _srep.Add(s);


            string fileName = Server.MapPath("../Images/" + u.Name + "_" + s.Id + ".jpg");
            var file = Request.Files["SharingImage"];
            file.SaveAs(fileName);

            s.SharingImage = u.Name + "_" + s.Id + ".jpg";
            _srep.Update(s);
            return RedirectToAction("Index");
        }

        public ActionResult CommentListPartial(int id)
        {
            Sharing model= _srep.Find(id);

            string str1 = JsonConvert.SerializeObject(model.Comments, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<CommentViewModel> comments = JsonConvert.DeserializeObject<List<CommentViewModel>>(str1);
            return PartialView(comments);
        }

        [HttpPost]
        public ActionResult AddComment(string text , int sharingId)
        {
            Comment com = new Comment();

            com.User = (User)Session["User"];
            com.Text = text;

            com.Sharing = _srep.Find(sharingId);
            _crep.Add(com);


            return View("CommentListPartial",sharingId);
        }

        public ActionResult DeleteComment(int id)
        {
            _crep.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult FriendShipRequests(int id)
        {

            string str2 = JsonConvert.SerializeObject(_fsrep.FSRList(id), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<FriendshipRequestViewModel> result = JsonConvert.DeserializeObject<List<FriendshipRequestViewModel>>(str2);

            Session["FSRUL"] = result;

            string str3 = JsonConvert.SerializeObject(_urep.List(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<UserViewModel> ulist = JsonConvert.DeserializeObject<List<UserViewModel>>(str3);



            return View(result);
        }

        public ActionResult FSRConfirm(int id)
        {

            FriendshipRequest entity = _fsrep.Find(id);
            entity.Status = 2;
            _fsrep.Update(entity);
            return RedirectToAction("FriendShipRequests", new { id = Session["Id"] });
        }

        public ActionResult FSRRefuse(int id)
        {

            FriendshipRequest entity = _fsrep.Find(id);
            entity.Status = 0;
            _fsrep.Update(entity);
            return RedirectToAction("FriendShipRequests", new { id = Session["Id"] });
        }


        public ActionResult FriendsSmallPartial(int id=0)
        {
            int Userid = Convert.ToInt32(Session["Id"]);
            List<FriendshipRequest> result = _fsrep.RandomFriends(Userid,id);

            string str1 = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<FriendshipRequestViewModel> model = JsonConvert.DeserializeObject<List<FriendshipRequestViewModel>>(str1);

            return PartialView(model);
        }

        [HttpPost]
        public JsonResult FriendsSmallPartialPost(int id)
        {
            Thread.Sleep(1000);
            int userid = Convert.ToInt32(Session["Id"]);
            List<FriendshipRequest> result = _fsrep.RandomFriends(userid, id);
            List<User> userlist = new List<User>();
            foreach (var item in result)
            {
                if (item.ReceiverUser.Id!=userid)
                {
                    userlist.Add(item.ReceiverUser);
                }
                else
                {
                    userlist.Add(item.SenderUser);
                }
            }

            string str1 = JsonConvert.SerializeObject(userlist, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<UserViewModel> model = JsonConvert.DeserializeObject<List<UserViewModel>>(str1);

            return Json(model,JsonRequestBehavior.AllowGet);
        }

        public ActionResult AllFriends()
        {
            int id = Convert.ToInt32(Session["Id"]);
            List<FriendshipRequest> result = _fsrep.Friends(id);

            string str1 = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<FriendshipRequestViewModel> model = JsonConvert.DeserializeObject<List<FriendshipRequestViewModel>>(str1);
            return View(model);
        }

        public ActionResult RemoveFriend(int id)
        {
            int secondid = Convert.ToInt32(Session["Id"]);
            _fsrep.RemoveFSR(id,secondid);
            return RedirectToAction("AllFriends");
        }

        public JsonResult FriendSearch(string txt)
        {
           
            string str1 = JsonConvert.SerializeObject(_urep.FilterList(txt), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<UserViewModel> model = JsonConvert.DeserializeObject<List<UserViewModel>>(str1);
            return Json(model,JsonRequestBehavior.AllowGet);
        }
    }
}