using System;
using System.Data.Entity;
using ttanks.demogame.Domain;
using ttanks.demogame.Services;

namespace ttanks.demogame
{
    public class GameContext : DbContext
    {
        public GameContext() :  base("name=GameEntities")
        {
            Database.SetInitializer(new GameInitializer());
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Player>().HasKey(k => k.Id);
            //modelBuilder.Entity<Match>().HasKey(k => k.Id);

            modelBuilder.Entity<Player>().HasMany(h => h.Matches)
                .WithMany()
                .Map(m=> m.ToTable("PlayerMatches"));
        }
    }

    public class GameInitializer : DropCreateDatabaseIfModelChanges<GameContext>
    {
        protected override void Seed(GameContext context)
        {
            var playerService = new PlayerServices();
            var jarvis = playerService.CreatePlayer("Jarvis");
            context.Players.Add(jarvis);

            context.SaveChanges();
        }
    }
}
