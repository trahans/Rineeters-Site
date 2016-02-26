using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;
using Rinita.Stephan.Helpers;
using Rinita.Stephan.Models;
using Rinita.Stephan.Wrappers;

namespace Rinita.Stephan.Tests.Helpers
{
    [TestFixture]
    public class GetHelperTests
    {
        private IGetHelper _getHelper;
        private IEntityWrapper _entityWrapper;

        [SetUp]
        public void SetUp()
        {
            _entityWrapper = Substitute.For<IEntityWrapper>();
            _getHelper = new GetHelper(_entityWrapper);
        }

        [Test]
        public void GetAllRsvps_NoProblems_CallsEntityWrapperGetAllRsvps()
        {
            // setup

            // action
            _getHelper.GetAllRsvps();

            // assert
            _entityWrapper.Received().GetAllRsvps();
        }

        [Test]
        public void GetAllRsvps_NoProblems_ReturnsCollectionOfRsvps()
        {
            // setup
            IEnumerable<RSVP> expectedRsvps = new List<RSVP>
            {
                new RSVP {Name = "Mister Test", Email = "test@example.com", RSVPed = false},
                new RSVP {Name = "Lady Test", Email = "anotherTest@example.com", RSVPed = true}
            };
            _entityWrapper.GetAllRsvps().Returns(expectedRsvps);

            // action
            IEnumerable<RSVP> rsvpResults = _getHelper.GetAllRsvps();

            // assert
            CollectionAssert.AreEquivalent(expectedRsvps, rsvpResults);
        }

        [Test]
        public void GetAllRsvps_ItemsInWrongOrder_ReturnsRsvpsInCorrectOrder()
        {
            // setup
            IEnumerable<RSVP> expectedRsvps = new List<RSVP>
            {
                new RSVP {Name = "Mister Test", Email = "test@example.com", RSVPed = false},
                new RSVP {Name = "Lady Test", Email = "anotherTest@example.com", RSVPed = true}
            };
            _entityWrapper.GetAllRsvps().Returns(expectedRsvps);

            // action
            IEnumerable<RSVP> rsvpResults = _getHelper.GetAllRsvps();
            var rsvpListResults = rsvpResults as IList<RSVP> ?? rsvpResults.ToList();

            // assert
            Assert.AreEqual(true, rsvpListResults[0].RSVPed);
            Assert.AreEqual(false, rsvpListResults[1].RSVPed);
        }

        [Test]
        public void GetAllRsvps_EntityWrapperReturnsNull_ReturnsEmptyListOfRsvps()
        {
            // setup
            _entityWrapper.GetAllRsvps().ReturnsNull();

            // action
            IEnumerable<RSVP> rsvpResults = _getHelper.GetAllRsvps();

            // assert
            Assert.AreEqual(Enumerable.Empty<RSVP>(), rsvpResults);
        }
    }
}
