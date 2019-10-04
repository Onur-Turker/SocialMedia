using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository:BaseRepository<User>,IUserRepository
    {
        Model1 _ctx;
        public UserRepository(Model1 ctx) : base(ctx )
        {
            _ctx = ctx;
        }


        //public void Add(User entity)
        //{
        //    ctx.Users.Add(entity);
        //    ctx.SaveChanges();
        //}

        //public void Update(User entity)
        //{
        //    User usr = ctx.Users.Find(entity.Id);
        //    ctx.Entry(entity).CurrentValues.SetValues(usr);
        //    ctx.SaveChanges();
        //}

        public  List<User> LoginControl(string Email, string Password)
        {
            List<User> result = _ctx.Users.Where(c => c.Email == Email && c.Password == Password).ToList();
            return result;
        }

        //public User UserFind(int id)
        //{
        //    User result = ctx.Users.Find(id);
        //    return result;
        //}

        public List<User> FilterList(string metin)
        {
            string yenimetin = metin.ToLower();
            List<User> result = _ctx.Users.Where(c => c.Name.ToLower().StartsWith(yenimetin)).ToList();
            return result;
        }
    }
}
