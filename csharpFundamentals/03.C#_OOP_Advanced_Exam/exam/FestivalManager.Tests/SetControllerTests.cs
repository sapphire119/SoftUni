// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

namespace FestivalManager.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using System.Reflection;

    [TestFixture]
	public class SetControllerTests
    {
        [Test]
        public void DidNotPerformOutput()
        {
            var stage = new Stage();
            var setController = new SetController(stage);

            var set = new Long("Very very very very long");
            stage.AddSet(set);

            var result = setController.PerformSets();

            var expected = "1. Very very very very long:\r\n-- Did not perform";

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void PerformedAtSet()
        {
            var stage = new Stage();
            var setController = new SetController(stage);

            var set = new Medium("TestMe");
            var performer = new Performer("ivan", 24, new Guitar());
            var song = new Song("given up", new TimeSpan(0, 3, 40));

            stage.AddSet(set);
            stage.AddPerformer(performer);
            stage.AddSong(song);
        }
    }
}