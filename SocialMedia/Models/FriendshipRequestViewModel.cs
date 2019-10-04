using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    public class FriendshipRequestViewModel
    {
        public int Id { get; set; }
        public short Status { get; set; }
        public UserViewModel SenderUser { get; set; }
        public UserViewModel ReceiverUser { get; set; }
    }
}