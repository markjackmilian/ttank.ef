namespace ttanks.demogame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nick = c.String(),
                        Luck = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchDate = c.DateTime(nullable: false),
                        Points = c.Int(nullable: false),
                        Winner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.Winner_Id)
                .Index(t => t.Winner_Id);
            
            CreateTable(
                "dbo.PlayerMatches",
                c => new
                    {
                        Player_Id = c.Int(nullable: false),
                        Match_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.Match_Id })
                .ForeignKey("dbo.Players", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.Matches", t => t.Match_Id, cascadeDelete: true)
                .Index(t => t.Player_Id)
                .Index(t => t.Match_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayerMatches", "Match_Id", "dbo.Matches");
            DropForeignKey("dbo.PlayerMatches", "Player_Id", "dbo.Players");
            DropForeignKey("dbo.Matches", "Winner_Id", "dbo.Players");
            DropIndex("dbo.PlayerMatches", new[] { "Match_Id" });
            DropIndex("dbo.PlayerMatches", new[] { "Player_Id" });
            DropIndex("dbo.Matches", new[] { "Winner_Id" });
            DropTable("dbo.PlayerMatches");
            DropTable("dbo.Matches");
            DropTable("dbo.Players");
        }
    }
}
