using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository:BaseRepository<Comment>,ICommentRepository
    {
        
        public CommentRepository(Model1 ctx):base(ctx)
        {
            
        }

        //public List<Comment> List()
        //{
        //    List<Comment> result = ctx.Comments.ToList();
        //    return result;
        //}

        //public void Add(Comment entity)
        //{
        //    ctx = new Model1();
        //    ctx.Comments.Add(entity);
        //    ctx.SaveChanges();
        //}
    }
}
