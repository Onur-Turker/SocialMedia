namespace DataAccessLayer
{
    using DataAccessLayer.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
    
        public Model1()
            : base("name=SMContext")
        {
        }

        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Sharing> Sharings { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FriendshipRequest> FriendshipRequests { get; set; }
    }


}