namespace ttanks.demogame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLoser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "Loser_Id", c => c.Int());
            CreateIndex("dbo.Matches", "Loser_Id");
            AddForeignKey("dbo.Matches", "Loser_Id", "dbo.Players", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Loser_Id", "dbo.Players");
            DropIndex("dbo.Matches", new[] { "Loser_Id" });
            DropColumn("dbo.Matches", "Loser_Id");
        }
    }
}
