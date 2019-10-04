namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Sharing_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sharings", t => t.Sharing_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Sharing_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Sharings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SharingCase = c.Int(nullable: false),
                        SharingDate = c.DateTime(nullable: false),
                        SharingText = c.String(),
                        SharingImage = c.String(),
                        Description = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        ProfilePhoto = c.String(),
                        Gender = c.String(),
                        Province = c.String(),
                        Coutry = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FriendshipRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Short(nullable: false),
                        ReceiverUser_Id = c.Int(),
                        SenderUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ReceiverUser_Id)
                .ForeignKey("dbo.Users", t => t.SenderUser_Id)
                .Index(t => t.ReceiverUser_Id)
                .Index(t => t.SenderUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sharings", "User_Id", "dbo.Users");
            DropForeignKey("dbo.FriendshipRequests", "SenderUser_Id", "dbo.Users");
            DropForeignKey("dbo.FriendshipRequests", "ReceiverUser_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Sharing_Id", "dbo.Sharings");
            DropIndex("dbo.FriendshipRequests", new[] { "SenderUser_Id" });
            DropIndex("dbo.FriendshipRequests", new[] { "ReceiverUser_Id" });
            DropIndex("dbo.Sharings", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropIndex("dbo.Comments", new[] { "Sharing_Id" });
            DropTable("dbo.FriendshipRequests");
            DropTable("dbo.Users");
            DropTable("dbo.Sharings");
            DropTable("dbo.Comments");
        }
    }
}
