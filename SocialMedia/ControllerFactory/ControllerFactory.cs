using DataAccessLayer;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repositories;
using SocialMedia.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SocialMedia.ControllerFactory
{
    public class ControllerFactory:DefaultControllerFactory
    {
        static Model1 ctx;
        static IUserRepository urep;
        static ISharingRepository srep;
        static ICommentRepository crep;
        static IFriendshipRequestRepository fsrep;
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (ctx==null)
            {
                ctx = new Model1();
            }

            if (urep==null)
            {
                urep = new UserRepository(ctx);
            }

            if (srep==null)
            {
                srep = new SharingrRepository(ctx);
            }

            if (crep == null)
            {
                crep = new CommentRepository(ctx);
            }

            if (fsrep==null)
            {
                fsrep = new FriendshipRequestRepository(ctx);
            }

            if (controllerName=="Login")
            {
                return new LoginController(urep);
            }

            if (controllerName=="HomePage")
            {
                return new HomePageController(urep,srep,crep,fsrep);
            }

            if (controllerName == "Profile")
            {
                return new ProfileController(urep);
            }

            if (controllerName=="MyProfile")
            {
                return new MyProfileController(urep,srep,crep);
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}