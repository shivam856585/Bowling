using Bowling.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Utility
{
    public class Scorer : IScorer
    {
        private int ball;
        private int[] rolls = new int[21];
        private int currentRoll;
        public void AddRoll(int pins)
        {
            rolls[currentRoll++] = pins;
        }
        public int ScoreForFrame(int theFrame)
        {
            ball = 0;
            int score = 0;
            for (int currentFrame = 0;
            currentFrame < theFrame;
            currentFrame++)
            {
                if (IsStrike)
                {
                    score += 10 + NextTwoBallsForStrike;
                    ball++;
                }
                else if (IsSpare)
                {
                    score += 10 + NextBallForSpare;
                    ball += 2;
                }
                else
                {
                    score += TwoBallsInFrame;
                    ball += 2;
                }
            }
            return score;
        }
        private int NextTwoBallsForStrike
        {
            get { return rolls[ball + 1] + rolls[ball + 2]; }
        }
        private int NextBallForSpare
        {
            get { return rolls[ball + 2]; }
        }
        private bool IsStrike
        {
            get => rolls[ball] == 10;
        }
        private int TwoBallsInFrame
        {
            get { return rolls[ball] + rolls[ball + 1]; }
        }
        private bool IsSpare
        {
            get => rolls[ball] + rolls[ball + 1] == 10;
        }
    }
}
