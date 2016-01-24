using NSubstitute;
using NUnit.Framework;
using Rinita.Stephan.Helpers;
using Rinita.Stephan.Models;
using Rinita.Stephan.Statics;
using Rinita.Stephan.Wrappers;

namespace Rinita.Stephan.Tests.Helpers
{
    [TestFixture]
    public class PostHelperTests
    {
        private PostHelper _postHelper;
        private IEntityWrapper _entityWrapper;

        [SetUp]
        public void SetUp()
        {
            _entityWrapper = Substitute.For<IEntityWrapper>();
            _postHelper = new PostHelper(_entityWrapper);
        }

        [Test]
        public void AddRsvp_CorrectData_CallingEntityWrapperAddRsvpItem()
        {
            // setup
            var rsvp = new RSVP {Name="Mister Test", Email="test@example.com"};

            // action
            _postHelper.AddRsvp(rsvp);

            // assert
            _entityWrapper.Received().AddRsvpItem(Arg.Any<RSVP>());
        }

        [Test]
        public void AddRsvp_CorrectData_ReturnsSuccessMessage()
        {
            // setup
            var rsvp = new RSVP { Name = "Mister Test", Email = "test@example.com" };

            // action
            var msg = _postHelper.AddRsvp(rsvp);

            // assert
            Assert.AreEqual(Constants.SuccessMessage, msg);
        }

        [Test]
        public void AddRsvp_NoValueForName_ReturnsErrorMessage()
        {
            // setup
            var rsvp = new RSVP {Email = "test@example.com"};

            // action
            var msg = _postHelper.AddRsvp(rsvp);

            // assert
            Assert.AreEqual(Constants.ErrorMessage, msg);
        }

        [Test]
        public void AddRsvp_NoValueForEmail_ReturnsErrorMessage()
        {
            // setup
            var rsvp = new RSVP { Name = "Mister Test" };

            // action
            var msg = _postHelper.AddRsvp(rsvp);

            // assert
            Assert.AreEqual(Constants.ErrorMessage, msg);
        }

        [Test]
        public void AddRsvp_NoValueForName_EntityWrapperAddRsvpItemNotCalled()
        {
            // setup
            var rsvp = new RSVP { Email = "test@example.com" };

            // action
            _postHelper.AddRsvp(rsvp);

            // assert
            _entityWrapper.DidNotReceive().AddRsvpItem(Arg.Any<RSVP>());
        }

        [Test]
        public void AddRsvp_NoValueForEmail_EntityWrapperAddRsvpItemNotCalled()
        {
            // setup
            var rsvp = new RSVP { Name = "Mister Test" };

            // action
            _postHelper.AddRsvp(rsvp);

            // assert
            _entityWrapper.DidNotReceive().AddRsvpItem(Arg.Any<RSVP>());
        }

        [Test]
        public void AddRsvp_PoorlyFormattedEmail_EmailIsFormattedProperly()
        {
            // setup
            var rsvp = new RSVP { Name = "Mister Test", Email = "tEsT@ExAmPlE.CoM"};

            // action
            _postHelper.AddRsvp(rsvp);

            // assert
            Assert.AreEqual("test@example.com", rsvp.Email);
        }

        [Test]
        public void AddRsvp_RsvpIsNull_ReturnsErrorMessage()
        {
            // setup

            // action
            var msg = _postHelper.AddRsvp(null);

            // assert
            Assert.AreEqual(Constants.ErrorMessage, msg);
        }

        [Test]
        public void AddRsvp_RsvpIsNull_EntityWrapperAddRsvpItemNotCalled()
        {
            // setup

            // action
            _postHelper.AddRsvp(null);

            // assert
            _entityWrapper.DidNotReceive().AddRsvpItem(Arg.Any<RSVP>());
            _entityWrapper.DidNotReceive().AddRsvpItem(null);
        }
    }
}
