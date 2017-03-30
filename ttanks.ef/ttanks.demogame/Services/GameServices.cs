using System;
using System.Data.Entity;
using System.Linq;
using ttanks.demogame.Domain;

namespace ttanks.demogame.Services
{
    internal class GameServices
    {
        private readonly PlayerServices _playService;
        private Random _random;

        public GameServices(PlayerServices playService)
        {
            _playService = playService;
            this._random = new Random(DateTime.Now.Millisecond);
        }

        public void StartNewGame()
        {
            Console.WriteLine("Insert your nickname");
            var nick = Console.ReadLine();

            var userByNick = this._playService.GetPlayerByNick(nick);

            if (userByNick == null)
            {
                Console.WriteLine($"No Player found for nick {nick}");
                StartNewGame();
                return;
            }

            var defaultPlayer = this._playService.GetDefaultPlayer();

            this.Fight(userByNick, defaultPlayer);
        }

        private void Fight(Player userByNick, Player defaultPlayer)
        {
            Console.WriteLine($"{defaultPlayer.Nick} move..");
            var defaultPoint = this.Move();
            Console.WriteLine($"{defaultPlayer.Nick} do {defaultPoint}");
            Console.WriteLine($"Evaluating luck ({defaultPlayer.Luck})..");
            var defaultPointWithLuck = this.MoveWithLuck(defaultPlayer, defaultPoint);
            Console.WriteLine($"Total with luck ({defaultPointWithLuck})..");

            Console.WriteLine("");

            Console.WriteLine($"Go {userByNick.Nick}! Press to make your move");
            Console.ReadLine();
            var userPoint = this.Move();
            Console.WriteLine($"{userByNick.Nick} do {userPoint}");
            Console.WriteLine($"Evaluating luck ({userByNick.Luck})..");
            var userPointWithLuck = this.MoveWithLuck(userByNick, userPoint);
            Console.WriteLine($"Total with luck ({userPointWithLuck})..");


            var userWin = userPointWithLuck >= defaultPointWithLuck;
            Console.WriteLine(userWin ? "You win!" : "You lose!");

            var match = new Match
            {
                MatchDate = DateTime.Now,
                Points = userWin ? userPointWithLuck : defaultPointWithLuck,
                Winner = userWin ? userByNick : defaultPlayer
            };


            var contextUSer = TheGame.GameContext.Players.Single(s => s.Id == userByNick.Id);
            TheGame.GameContext.Entry(contextUSer).State = EntityState.Modified;
            contextUSer.Matches.Add(match);


            var defaultContext = TheGame.GameContext.Players.Single(s => s.Id == GameConfig.Instance.JarvisId);
            TheGame.GameContext.Entry(defaultContext).State = EntityState.Modified;

            defaultContext.Matches.Add(match);


            TheGame.GameContext.SaveChanges();


            TheGame.Start();

        }

        private int Move()
        {
            return this._random.Next(0, GameConfig.Instance.MaxMove);
        }

        private int MoveWithLuck(Player player, int point)
        {
            var luck = player.Luck;
            if (point < luck)
            {
                return point + 5;
            }
            return point;
        }
    }
}