using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Interface
{
    public interface IScorer
    {
        public void AddRoll(int pins);
        public int ScoreForFrame(int theFrame);
    }
}
