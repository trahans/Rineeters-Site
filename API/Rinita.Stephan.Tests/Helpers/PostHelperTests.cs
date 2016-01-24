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
            var rsvp = new RSVP();

            // action
            _postHelper.AddRsvp(rsvp);

            // assert
            _entityWrapper.Received().AddRsvpItem(Arg.Any<RSVP>());
        }

        [Test]
        public void AddRsvp_PoorlyFormattedEmail_EmailIsFormattedProperly()
        {
            // setup
            var rsvp = new RSVP {Email = "tEsT@ExAmPlE.CoM"};

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
            
        }
    }
}
