using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IFriendshipRequestRepository:IBaseRepository<FriendshipRequest>
    {
        List<FriendshipRequest> FSRList(int id);
        List<FriendshipRequest> Friends(int id);
        List<FriendshipRequest> RandomFriends(int id, int start);
        void RemoveFSR(int firstid, int secondid);
    }
}
