using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealth()
        {
            var axe = new Axe(1, 10);
            var dummy = new Dummy(10, 100);

            dummy.TakeAttack(axe.AttackPoints);

            Assert.That(dummy.Health, Is.EqualTo(9));
        }

        [Test]
        public void DeadDummyThrowsException()
        {
            var axe = new Axe(1, 10);
            var dummy = new Dummy(0, 20);

            Assert.That(() => dummy.TakeAttack(axe.AttackPoints),
                Throws.InvalidOperationException.With.
                Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyShouldGiveXp()
        {
            var axe = new Axe(1, 10);
            var dummy = new Dummy(0, 10);

            Assert.That(dummy.GiveExperience, Is.EqualTo(10));
            //Assert.AreEqual(10, dummy.Health);
        }

        [Test]
        public void AliveDummyShouldNotGiveXp()
        {
            var dummy = new Dummy(1, 10);

            Assert.That(() => dummy.GiveExperience(),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Target is not dead."));
        }
    }
}
