using Capitalism.Logic.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capitalism.Logic.Test.PlayerTests
{
    [TestClass]
    public class PlayerHealthTests
    {
        [TestMethod]
        public void Increase_Health_Should_Not_Exceed_100()
        {
            var player = Player.CreateNewPlayer("Player 1", "Player 1");
            player.AddHealth(1000);
            Assert.AreEqual(100, player.Health);
        }

        [TestMethod]
        public void Reduce_Health_Should_Not_Be_Negative()
        {
            var player = Player.CreateNewPlayer("Player 1", "Player 1");
            player.ReduceHealth(1000);
            Assert.AreEqual(0, player.Health);
        }

        [TestMethod]
        public void Reduce_Health_Should_Decrease_Health()
        {
            var player = Player.CreateNewPlayer("Player 1", "Player 1");
            var endingHealth = player.Health - 10;
            player.ReduceHealth(10);
            Assert.AreEqual(endingHealth, player.Health);
        }

        [TestMethod]
        public void Increase_Health_Should_Increase_Health()
        {
            var player = Player.CreateNewPlayer("Player 1", "Player 1");
            var endingHealth = player.Health - 10;
            player.ReduceHealth(20);
            player.AddHealth(10);
            Assert.AreEqual(endingHealth, player.Health);
        }

        [TestMethod]
        public void Positive_Health_Should_Be_Alive()
        {
            var player = Player.CreateNewPlayer("Player 1", "Player 1");
            player.ReduceHealth(99);
            Assert.IsTrue(player.IsAlive);
        }

        [TestMethod]
        public void Zero_Health_Should_Not_Be_Alive()
        {
            var player = Player.CreateNewPlayer("Player 1", "Player 1");
            player.ReduceHealth(1000);
            Assert.IsFalse(player.IsAlive);
        }
    }
}
