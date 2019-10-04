using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Models
{
    public class UserViewModel
    {


        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }


        public string ProfilePhoto { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        public string Coutry { get; set; }

        [Required]
        public string City { get; set; }

        [JsonIgnore]
        public List<SharingViewModel> Sharings { get; set; }

        public List<CommentViewModel> Comments { get; set; }


        public  List<FriendshipRequestViewModel> Senders { get; set; }

        public  List<FriendshipRequestViewModel> Receivers { get; set; }

    }
}