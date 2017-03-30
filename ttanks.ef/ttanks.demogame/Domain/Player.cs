using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ttanks.demogame.Domain
{
    public class Player : DomainBase
    {

        public Player()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            this.Matches = new List<Match>();
        }

        public string Nick { get; set; }
        public int Luck { get; set; }

        public virtual ICollection<Match> Matches { get; set; }

        
    }
}
