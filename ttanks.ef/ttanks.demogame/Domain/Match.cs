using System;

namespace ttanks.demogame.Domain
{
    public class Match : DomainBase
    {
        public DateTime MatchDate { get; set; }

        public int Points { get; set; }

        public virtual Player Winner { get; set; }
    }
}