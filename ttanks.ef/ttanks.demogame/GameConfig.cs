using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttanks.demogame
{
    internal class GameConfig
    {
        private static GameConfig _instance;

        private GameConfig()
        {}

        public static GameConfig Instance => _instance ?? (_instance = new GameConfig());

        public int MinLuck => 1;
        public int MaxLuck => 20;

        /// <summary>
        /// Id for Computer player
        /// </summary>
        public int JarvisId = 1;

        /// <summary>
        /// Create a random luck between MinLuck and MaxLuck
        /// </summary>
        /// <returns></returns>
        public int GetRandomLuck()
        {
            var random = new Random(DateTime.Now.Millisecond);
            return random.Next(this.MinLuck, this.MaxLuck);
        }

    }
}
