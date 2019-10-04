using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SharingrRepository:BaseRepository<Sharing>,ISharingRepository
    {
        Model1 _ctx;
        public SharingrRepository(Model1 ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public override List<Sharing> List()
        {
            List<Sharing> result = _ctx.Sharings.OrderByDescending(c => c.Id).Take(5).ToList();
            return result;
        }

        public List<Sharing> ListHomePage(int id = -1)
        {
            List<Sharing> result = _ctx.Sharings.Where(c => c.Id > id).OrderByDescending(c => c.Id).Take(5).ToList();
            return result;
        }

        public  List<Sharing> MyProfileList(int id)
        {
            List<Sharing> result = _ctx.Sharings.OrderByDescending(c => c.Id).Where(c=>c.User.Id==id).ToList();
            return result;
        }



        public User UserFind(int id)
        {
            User result = _ctx.Users.Find(id);
            return result;
        }

        //public void Update(Sharing entity)
        //{
        //   Sharing s = ctx.Sharings.Find(entity.Id);
        //    ctx.Entry(entity).CurrentValues.SetValues(s);
        //    ctx.SaveChanges();
        //}

    }
}
