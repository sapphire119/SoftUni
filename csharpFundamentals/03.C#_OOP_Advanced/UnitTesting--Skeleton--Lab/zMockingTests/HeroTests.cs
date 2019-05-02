using Moq;
using NUnit.Framework;
using System;

namespace zMockingTests
{
    public class HeroTests
    {
        [Test]
        public void HeroGainsXPAfterDummyDies()
        {
            Mock<IDummy> fakeDummy = new Mock<IDummy>();
            fakeDummy.Setup(d => d.Health).Returns(0);
            fakeDummy.Setup(d => d.GiveExperience()).Returns(10);
            fakeDummy.Setup(d => d.IsDead()).Returns(true);

            Mock<IAxe> fakeAxe = new Mock<IAxe>();
            fakeAxe.Setup(a => a.AttackPoints).Returns(10);
            fakeAxe.Setup(a => a.DurabilityPoints).Returns(20);

            IHero hero = new Hero("Pesho", fakeAxe.Object);

            hero.Attack(fakeDummy.Object);
            fakeAxe.Verify(w => w.Attack(fakeDummy.Object)); //Верифицира дали е извикан Attack Метода на Weapon

            var expectedExperience = 10;

            Assert.That(hero.Experience, Is.EqualTo(expectedExperience));
        }

        //[Test]
        //public void TestMocking()
        //{
        //    Mock<IAxe> weapon = new Mock<IAxe>();
        //    weapon.Setup(w => w.AttackPoints).Returns(10);
        //    weapon.Setup(w => w.DurabilityPoints).Returns(20);

        //    IHero hero = new Hero("Pesho", weapon.Object);

        //    Mock<IDummy> fakeTarget = new Mock<IDummy>();

        //    fakeTarget.Setup(p => p.TakeAttack(It.IsAny<int>()))
        //        .Callback(() => hero.Weapon.DurabilityPoints -= 1);
        //}
    }
}
