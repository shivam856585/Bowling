using Xunit;
using Moq;
using Bowling.Interface;

namespace Bowling.Test
{
    public class BowlingFactoryTest
    {
        private readonly Mock<IScorer> _scorrer;

        public BowlingFactoryTest()
        {
            _scorrer = new Mock<IScorer>();
        }

        [Fact]
        public void BolwingFactory_GivenScorer_ReturnsBowlingGame()
        {
           var scorrer = _scorrer.Object;
           var factory = new BowlingFactory(scorrer);
           
           var bowlingGame = factory.Create();

           Assert.IsType<BowlingGame>(bowlingGame);
        }

        [Fact]
        public void BowlingFactory_WithNullScorer_ThrowsException()
        {
            var exceptionType = typeof(ArgumentNullException);
            Assert.Throws(exceptionType, () => {
                new BowlingFactory(null);
            });
        }

    }
}