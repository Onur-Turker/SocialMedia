using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Sharing
    {
        public Sharing()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public int SharingCase { get; set; }
        public DateTime SharingDate { get; set; }
        public string SharingText { get; set; }
        public string SharingImage { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
