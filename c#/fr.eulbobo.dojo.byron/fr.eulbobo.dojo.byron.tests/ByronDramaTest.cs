using fr.eulbobo.dojo.byron.domain;
using Moq;

namespace fr.eulbobo.dojo.byron.tests
{
    public class ByronDramaTest
    {
        /**
         * 1    | He needs help reading this fan mail                | +1 Stress  |
         */
        [Test]
        public void ShouldAdd1StressWhenRolls1()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new ByronDrama(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(1), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He needs help reading this fan mail"));
            sanity.Verify(s => s.IncreaseStress(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 2    | He's brought his pet bear. It is not trained       | +2 Stress  |
         */
        [Test]
        public void ShouldAdd2StressWhenRolls2()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new ByronDrama(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(2), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He's brought his pet bear. It is not trained"));
            sanity.Verify(s => s.IncreaseStress(), Times.Exactly(2));
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 3    | He wants to read you his poetry                    | +3 Stress  |
         */
        [Test]
        public void ShouldAdd3StressWhenRolls3()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new ByronDrama(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(3), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He wants to read you his poetry"));
            sanity.Verify(s => s.IncreaseStress(), Times.Exactly(3));
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 4    | He's in the papers. Again. Which means you are too | +1 Scandal |
         */
        [Test]
        public void ShouldAdd1ScandalWhenRolls4()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new ByronDrama(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(4), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He's in the papers. Again. Which means you are too"));
            sanity.Verify(s => s.IncreaseScandal(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 5    | He broke up with his latest girlfriend/boyfriend   | +2 Scandal |
         */
        [Test]
        public void ShouldAdd2ScandalWhenRolls5()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new ByronDrama(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(5), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He broke up with his latest girlfriend/boyfriend"));
            sanity.Verify(s => s.IncreaseScandal(), Times.Exactly(2));
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 6    | He's found a new skull to use as a goblet          | +3 Scandal |
         */
        [Test]
        public void ShouldAdd3ScandalWhenRolls6()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new ByronDrama(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(6), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He's found a new skull to use as a goblet"));
            sanity.Verify(s => s.IncreaseScandal(), Times.Exactly(3));
            sanity.VerifyNoOtherCalls();
        }
    }
}
