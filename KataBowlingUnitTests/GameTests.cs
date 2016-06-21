using KataBowling;
using NUnit.Framework;

namespace KataBowlingUnitTests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void ZeroScoreGame()
        {
            var game = new Game();

            for (int ii = 0; ii < 20; ii++)
            {
                game.Roll(0);
            }

            Assert.AreEqual(0, game.Score());
        }

        [Test]
        public void ScoreOnce_EveryThrow()
        {
            var game = new Game();

            for (int ii = 0; ii < 20; ii++)
            {
                game.Roll(1);
            }

            Assert.AreEqual(20, game.Score());
        }

        [Test]
        public void SpareOnFirstThrow()
        {
            var game = new Game();

            game.Roll(5);
            game.Roll(5);

            for (int ii = 0; ii < 18; ii++)
            {
                game.Roll(1);
            }

            Assert.AreEqual(29, game.Score());
        }

        [Test]
        public void StrikeOnFirstThrow()
        {
            var game = new Game();

            game.Roll(10);

            for (int ii = 0; ii < 18; ii++)
            {
                game.Roll(1);
            }

            Assert.AreEqual(30, game.Score());
        }

        [Test]
        public void FirstStrikeFollowedBySpare()
        {
            var game = new Game();

            game.Roll(10);
            game.Roll(5);
            game.Roll(5);

            for (int ii = 0; ii < 16; ii++)
            {
                game.Roll(1);
            }

            Assert.AreEqual(47, game.Score());
        }

        [Test]
        public void TwoFollowingStrikes()
        {
            var game = new Game();

            game.Roll(10);
            game.Roll(10);

            for (int ii = 0; ii < 16; ii++)
            {
                game.Roll(1);
            }

            Assert.AreEqual(48, game.Score());
        }
    }
}
