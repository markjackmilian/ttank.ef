using System;
using ttanks.demogame.Services;

namespace ttanks.demogame
{
    internal static class TheGame
    {
        public static void Start()
        {
            Console.WriteLine("Press n for new player.");
            Console.WriteLine("Press e for new exit.");
            var cmd = Console.ReadLine();

            // no input found
            if (string.IsNullOrEmpty(cmd))
            {
                Retry();
                return;
            } 

            // manage choices
            switch (cmd)
            {
                case "n":
                    ManageNewPlayer();
                    break;
                case "e":
                    Exit();
                    break;
                default:
                    Retry();
                    return;
            }
        }

        private static void Retry()
        {
            Console.WriteLine("No input found!");
            Start();
        }

        private static void ManageNewPlayer()
        {
            var playerService = new PlayerServices();
            playerService.NewPlayerManager();
        }


        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}