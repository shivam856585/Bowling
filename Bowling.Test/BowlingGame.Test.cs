using Xunit;
using Moq;
using Bowling.Interface;
using Bowling.Utility;

namespace Bowling.Test
{
    public class BowlingGameTest
    {
        private IScorer _scorrer;
        private IBowlingGame blowingGame;

        public BowlingGameTest()
        {
            _scorrer = new Scorer();
            blowingGame = new BowlingGame(_scorrer);
        }

        [Trait("Game", "CompleteFrames")]
        [Theory]
        [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0)]
        [InlineData(new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 }, 300)]
        [InlineData(new int[] { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 }, 187)]
        public void BolwingGame_GivenCompleteRolls_ReturnsScore(int[] playedFrames, int ExpectedScore)
        {
            for (int i = 0; i < playedFrames.Length; i++)
            {
                blowingGame.Add(playedFrames[i]);
            }
            var finalScore = blowingGame.Score;
            Assert.Equal(ExpectedScore, finalScore);
        }

        [Trait("Game", "IncompleteFrames")]
        [Theory]
        [InlineData(new int[] { 0, 0, 0, 0, 0, 0, 0, 0 }, 0)]
        [InlineData(new int[] { 10, 10, 10 }, 60)]
        [InlineData(new int[] { 5, 5, 5, 5 }, 25)]
        public void BolwingGame_IncompleteRolls_ReturnsScore(int[] playedFrames, int ExpectedScore)
        {
            for (int i = 0; i < playedFrames.Length; i++)
            {
                blowingGame.Add(playedFrames[i]);
            }
            var finalScore = blowingGame.Score;
            Assert.Equal(ExpectedScore, finalScore);
        }

        [Fact]
        public void BowlingGame_WithNullScorer_ThrowsException()
        {
            var exceptionType = typeof(ArgumentNullException);
            Assert.Throws(exceptionType, () => {
                new BowlingGame(null);
            });
        }

        [Fact]
        public void BowlingGame_SetNullScorer_ThrowsException()
        {
            var exceptionType = typeof(ArgumentNullException);
            Assert.Throws(exceptionType, () => {
                blowingGame.SetScorer(null);
            });
        }

        [Fact]
        public void BowlingGame_SetNewScorer_ThrowsException()
        {
            var newScorer = new Scorer();

            var oldScorerObjetc = blowingGame._scorer;
            blowingGame.SetScorer(newScorer);
            var newScorerObject = blowingGame._scorer;

            Assert.NotEqual(oldScorerObjetc, newScorerObject);
            Assert.IsType<Scorer>(newScorer);

        }


    }
}