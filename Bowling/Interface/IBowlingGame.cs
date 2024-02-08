using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Interface
{
    public interface IGame
    {
        public void Add(int pins);
        public int Score { get; }
        public IScorer _scorer { get; }

    }

    public interface IScorerStratergy
    {
        public void SetScorer(IScorer scorer);
    }

    public interface IBowlingGame : IScorerStratergy, IGame { }
}
