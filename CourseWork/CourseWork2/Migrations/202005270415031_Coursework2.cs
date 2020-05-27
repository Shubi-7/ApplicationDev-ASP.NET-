namespace CourseWork2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Coursework2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumArtists",
                c => new
                    {
                        ArtistId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.AlbumId })
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.Artists", t => t.ArtistId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.AlbumId);
            
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CopyNumber = c.String(),
                        Studio = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        TrackLength = c.String(),
                        IsAgeBar = c.Boolean(nullable: false),
                        FinePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AlbumImagePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 55),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Studio = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Loans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        AlbumId = c.Int(nullable: false),
                        LoanTypeId = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FineAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IssueDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Albums", t => t.AlbumId, cascadeDelete: true)
                .ForeignKey("dbo.LoanTypes", t => t.LoanTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.AlbumId)
                .Index(t => t.LoanTypeId);
            
            CreateTable(
                "dbo.LoanTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Days = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MembershipNo = c.String(nullable: false),
                        FullName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        Contact = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        MemberCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MemberCategories", t => t.MemberCategoryId, cascadeDelete: true)
                .Index(t => t.MemberCategoryId);
            
            CreateTable(
                "dbo.MemberCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        TotalLoan = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ArtistAlbums",
                c => new
                    {
                        Artist_Id = c.Int(nullable: false),
                        Album_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Artist_Id, t.Album_id })
                .ForeignKey("dbo.Artists", t => t.Artist_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_id, cascadeDelete: true)
                .Index(t => t.Artist_Id)
                .Index(t => t.Album_id);
            
            CreateTable(
                "dbo.ProducerAlbums",
                c => new
                    {
                        Producer_Id = c.Int(nullable: false),
                        Album_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Producer_Id, t.Album_id })
                .ForeignKey("dbo.Producers", t => t.Producer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Albums", t => t.Album_id, cascadeDelete: true)
                .Index(t => t.Producer_Id)
                .Index(t => t.Album_id);
            
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Loans", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "MemberCategoryId", "dbo.MemberCategories");
            DropForeignKey("dbo.Loans", "LoanTypeId", "dbo.LoanTypes");
            DropForeignKey("dbo.Loans", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.AlbumArtists", "ArtistId", "dbo.Artists");
            DropForeignKey("dbo.AlbumArtists", "AlbumId", "dbo.Albums");
            DropForeignKey("dbo.ProducerAlbums", "Album_id", "dbo.Albums");
            DropForeignKey("dbo.ProducerAlbums", "Producer_Id", "dbo.Producers");
            DropForeignKey("dbo.ArtistAlbums", "Album_id", "dbo.Albums");
            DropForeignKey("dbo.ArtistAlbums", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.ProducerAlbums", new[] { "Album_id" });
            DropIndex("dbo.ProducerAlbums", new[] { "Producer_Id" });
            DropIndex("dbo.ArtistAlbums", new[] { "Album_id" });
            DropIndex("dbo.ArtistAlbums", new[] { "Artist_Id" });
            DropIndex("dbo.Members", new[] { "MemberCategoryId" });
            DropIndex("dbo.Loans", new[] { "LoanTypeId" });
            DropIndex("dbo.Loans", new[] { "AlbumId" });
            DropIndex("dbo.Loans", new[] { "MemberId" });
            DropIndex("dbo.AlbumArtists", new[] { "AlbumId" });
            DropIndex("dbo.AlbumArtists", new[] { "ArtistId" });
            DropColumn("dbo.AspNetUsers", "FullName");
            DropTable("dbo.ProducerAlbums");
            DropTable("dbo.ArtistAlbums");
            DropTable("dbo.MemberCategories");
            DropTable("dbo.Members");
            DropTable("dbo.LoanTypes");
            DropTable("dbo.Loans");
            DropTable("dbo.Producers");
            DropTable("dbo.Artists");
            DropTable("dbo.Albums");
            DropTable("dbo.AlbumArtists");
        }
    }
}
