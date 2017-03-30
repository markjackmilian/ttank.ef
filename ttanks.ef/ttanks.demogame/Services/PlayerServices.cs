using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            using (var context = new GameContext())
            {
                var userByNick =
                    context.Players.SingleOrDefault(
                        sd => sd.Nick.Equals(nick, StringComparison.CurrentCultureIgnoreCase));

                if (userByNick != null)
                {
                    Console.WriteLine("Nick already in use!");
                    NewPlayerManager();
                    return;
                }

                context.Players.Add(this.CreatePlayer(nick));
                context.SaveChanges();

                Console.WriteLine("Player Created!");


                TheGame.Start();
                return;
            }
        }


        public Player CreatePlayer(string nick)
        {
            return new Player
            {
                Nick = nick,
                Luck = GameConfig.Instance.GetRandomLuck()
            };
        }
    }

}
