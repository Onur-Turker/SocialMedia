using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class FriendshipRequest
    {
        public int Id { get; set; }
        public short Status { get; set; }
        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }
    }
}
