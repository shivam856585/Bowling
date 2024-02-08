using Bowling.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class BowlingFactory : IBowlingFactory
    {
        private readonly IScorer _scorer;

        public BowlingFactory(IScorer scorer)
        {
            _scorer = scorer ?? throw new ArgumentNullException(nameof(scorer));
        }

        public IBowlingGame Create()
        {
            return new BowlingGame(_scorer);
        }
    }
}
