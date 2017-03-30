using System;
using System.Linq;
using ttanks.demogame.Domain;

namespace ttanks.demogame.Services
{
    internal class PlayerServices
    {
        public void NewPlayerManager()
        {
            Console.WriteLine("Enter a new univoque Nick: ");
            var nick = Console.ReadLine();

            if (string.IsNullOrEmpty(nick))
            {
                Console.WriteLine("You must insert a nick!");
                NewPlayerManager();
                return;
            }

            
                var userByNick = this.GetPlayerByNick(nick);

                if (userByNick != null)
                {
                    Console.WriteLine("Nick already in use!");
                    NewPlayerManager();
                    return;
                }

            TheGame.GameContext.Players.Add(this.CreatePlayer(nick));
            TheGame.GameContext.SaveChanges();

                Console.WriteLine("Player Created!");
                TheGame.Start();
            
        }

        public Player GetPlayerByNick(string nick)
        {
            return TheGame.GameContext.Players.SingleOrDefault(s=>s.Nick.Equals(nick,StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// Get computer player
        /// </summary>
        /// <returns></returns>
        public Player GetDefaultPlayer()
        {
            return TheGame.GameContext.Players.Single(s => s.Id == GameConfig.Instance.JarvisId);
        }

        public Player CreatePlayer(string nick)
        {
            return new Player
            {
                Nick = nick,
                Luck = GameConfig.Instance.GetRandomLuck()
            };
        }

        public void HistoryForPlayer()
        {
            Console.WriteLine("Insert your nick");
            var nick = Console.ReadLine();

            if (string.IsNullOrEmpty(nick))
            {
                HistoryForPlayer();
                return;
            }

            var player = this.GetPlayerByNick(nick);

            var matches = player.Matches.OrderByDescending(o=>o.MatchDate).ToList();

            matches.ForEach(f =>
            {
                var win = f.Winner.Id == player.Id ? "Win" : "Lose";

                Console.WriteLine($"{f.MatchDate.ToString("dd.MM.yy HH:mm")} - {f.Points} - {win}!");
            });

            Console.WriteLine($"You play {matches.Count} times!");
            Console.WriteLine($"You win {matches.Count(c=>c.Winner.Id == player.Id)} times!");

            Console.ReadLine();
            TheGame.Start();
        }
    }
}
