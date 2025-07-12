using fr.eulbobo.dojo.byron.domain;
using Moq;

namespace fr.eulbobo.dojo.byron.tests
{
    public class DisasterMuseTest
    {
        [Test]
        public void ShouldGetDisasterMuseAfter3rollsResultingIn6()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            DisasterMuse disasterMuse = new DisasterMuse(sanity.Object, eventLog.Object);
            disasterMuse.DiceRollIs(DiceRoll.Of(6));
            sanity.VerifyNoOtherCalls();
            eventLog.VerifyNoOtherCalls();
            disasterMuse.DiceRollIs(DiceRoll.Of(6));
            sanity.VerifyNoOtherCalls();
            eventLog.VerifyNoOtherCalls();
            disasterMuse.DiceRollIs(DiceRoll.Of(6));
            sanity.Verify(s => s.Disaster());
            eventLog.Verify(evtl => evtl.Log("Byron destroys your manuscript either by accident or on purpose, during one of his episodes"));
            sanity.VerifyNoOtherCalls();
        }

        [Test]
        public void ShouldNotGetDisasterMuseAfterAFourth6Roll()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            DisasterMuse disasterMuse = new DisasterMuse(sanity.Object, eventLog.Object);
            disasterMuse.DiceRollIs(DiceRoll.Of(6));
            disasterMuse.DiceRollIs(DiceRoll.Of(6));
            disasterMuse.DiceRollIs(DiceRoll.Of(6));
            disasterMuse.DiceRollIs(DiceRoll.Of(6));
            sanity.Verify(s => s.Disaster());
            eventLog.Verify(evtl => evtl.Log("Byron destroys your manuscript either by accident or on purpose, during one of his episodes"));
            sanity.VerifyNoOtherCalls();
            eventLog.VerifyNoOtherCalls();
        }
    }
}
