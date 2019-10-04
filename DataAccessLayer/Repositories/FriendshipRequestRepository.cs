using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class FriendshipRequestRepository:BaseRepository<FriendshipRequest>,IFriendshipRequestRepository
    {
        Model1 _ctx;
        public FriendshipRequestRepository(Model1 ctx):base(ctx)
        {
            _ctx = ctx;
        }      

        public List<FriendshipRequest> FSRList(int id)
        {
            List<FriendshipRequest> result = _ctx.FriendshipRequests.Where(c => c.ReceiverUser.Id == id && c.Status == 1).ToList();

            return result;
        }

        public List<FriendshipRequest> Friends(int id)
        {
            List<FriendshipRequest> result = _ctx.FriendshipRequests.Where(c => (c.ReceiverUser.Id == id || c.SenderUser.Id == id) && c.Status == 2).ToList();

            return result;
        }

        public List<FriendshipRequest> RandomFriends(int id, int start)
        {
            List<FriendshipRequest> result = _ctx.FriendshipRequests.Where(c => (c.ReceiverUser.Id == id || c.SenderUser.Id == id) && c.Status == 2).Where(c=>c.Id>start).Take(4).ToList();
            
            return result;
        }

        public void RemoveFSR(int firstid, int secondid)
        {
            FriendshipRequest entity = _ctx.FriendshipRequests.Where(c=>(c.SenderUser.Id==firstid || c.ReceiverUser.Id==firstid
            )&&(c.SenderUser.Id==secondid || c.ReceiverUser.Id==secondid)).ToList().FirstOrDefault();
            _ctx.FriendshipRequests.Remove(entity);
            _ctx.SaveChanges();
        }
    }
}
