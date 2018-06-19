using NUnit.Framework;
using System;

namespace Tests
{
    public class AxeTests
    {
        private const int AxeAttackDamage = 20;
        private const int AxeDurability = 2;
        private const int DummyHealth = 40;
        private const int DummyAwardingExperience = 20;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttackDamage, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyAwardingExperience);
        }

        [Test]
        public void AxeLosesDurability()
        {
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints, Is.EqualTo(1), "Axe durability doesn't change after attack");
            //Assert.AreEqual(4, axe.DurabilityPoints);
        }

        [Test]
        public void AttackingWithBrokenWeapon()
        {
            //Arrange
            axe.Attack(dummy);
            axe.Attack(dummy);
            //Act, Assert
            Assert.That(() => axe.Attack(dummy), 
                Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
        }
    }
}
