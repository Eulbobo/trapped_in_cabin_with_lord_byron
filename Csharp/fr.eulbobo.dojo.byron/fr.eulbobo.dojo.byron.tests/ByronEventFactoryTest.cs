using fr.eulbobo.dojo.byron.domain;
using Moq;

namespace fr.eulbobo.dojo.byron.tests
{
    public class ByronEventFactoryTest
    {

        [TestCase(1, typeof(ByronRecreation))]
        [TestCase(2, typeof(ByronRecreation))]
        [TestCase(3, typeof(ByronDrama))]
        [TestCase(4, typeof(ByronDrama))]
        [TestCase(5, typeof(BriefRedoubt))]
        [TestCase(6, typeof(BriefRedoubt))]
        public void ShouldGetCorrectByronEventOnDiceRoll(int roll, Type expectedInterface)
        {
            var eventLog = new Mock<EventLog>();
            ByronEventFactory factory = new ByronEventFactory(eventLog.Object);
            Assert.IsInstanceOf(expectedInterface, factory.From(DiceRoll.Of(roll)));
        }
    }
}
