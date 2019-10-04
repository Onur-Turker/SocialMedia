using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class User
    {
        public User()
        {
            Sharings = new List<Sharing>();
            Comments = new List<Comment>();
            Senders = new List<FriendshipRequest>();
            Receivers = new List<FriendshipRequest>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay { get; set; }
        public string ProfilePhoto { get; set; }
        public string Gender { get; set; }
        public string Province { get; set; }
        public string Coutry { get; set; }
        public string City { get; set; }
        public virtual List<Sharing> Sharings { get; set; }
        public virtual List<Comment> Comments { get; set; }
        [InverseProperty("SenderUser")]
        public virtual List<FriendshipRequest> Senders { get; set; }
        [InverseProperty("ReceiverUser")]
        public virtual List<FriendshipRequest> Receivers { get; set; }
       
       
    }
}
