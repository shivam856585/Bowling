using Bowling.Interface;

namespace Bowling
{
    public class BowlingGame : IBowlingGame
    {
        private int currentFrame = 0;
        private bool isFirstThrow = true;

        public IScorer _scorer { get; private set; }

        public BowlingGame(IScorer scorer)
        {
            _scorer = scorer ?? throw new ArgumentNullException(nameof(scorer));
        }

        public int Score
        {
            get { return ScoreForFrame(currentFrame); }
        }
        public void SetScorer(IScorer scorer) => _scorer = scorer ?? throw new ArgumentNullException(nameof(scorer));

        public void Add(int pins)
        {
            _scorer.AddRoll(pins);
            AdjustCurrentFrame(pins);
        }

        private void AdjustCurrentFrame(int pins)
        {
            if (LastBallInFrame(pins))
                AdvanceFrame();
            else
                isFirstThrow = false;
        }
        private bool LastBallInFrame(int pins)
        {
            return Strike(pins) || (!isFirstThrow);
        }
        private bool Strike(int pins)
        {
            return (isFirstThrow && pins == 10);
        }
        private void AdvanceFrame()
        {
            currentFrame++;
            if (currentFrame > 10)
                currentFrame = 10;
        }
        private int ScoreForFrame(int theFrame)
        {
            return _scorer.ScoreForFrame(theFrame);
        }
    }

}