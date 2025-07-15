using fr.eulbobo.dojo.byron.domain;
using Moq;

namespace fr.eulbobo.dojo.byron.tests
{
    public class BriefRedoubtTest
    {

        /**
         * | 1    | Time alone. Blissful time.                         | +1 Masterpiece                 |
         */
        [Test]
        public void ShouldAdd1MasterPieceWhenRolls1()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new BriefRedoubt(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(1), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("Time alone. Blissful time."));
            sanity.Verify(s => s.IncreaseMasterpiece(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * | 2    | He's busy with a paramour.                         | -1 Stress                      |
         */
        [Test]
        public void ShouldDecrease1StressWhenRolls2()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new BriefRedoubt(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(2), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He's busy with a paramour."));
            sanity.Verify(s => s.DecreaseStress(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * | 3    | A walk around the house ! Underwear on our heads ! | +1 Scandal                     |
         */
        [Test]
        public void ShouldIncrease1ScandalWhenRolls3()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new BriefRedoubt(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(3), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("A walk around the house ! Underwear on our heads !"));
            sanity.Verify(s => s.IncreaseScandal(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * | 4    | He has an excellent supply of contraband substance | +1 Scandal <br> +1 Masterpiece |
         */
        [Test]
        public void ShouldIncrease1ScandalAndMasterpieceWhenRolls4()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new BriefRedoubt(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(4), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He has an excellent supply of contraband substance"));
            sanity.Verify(s => s.IncreaseScandal(), Times.Once);
            sanity.Verify(s => s.IncreaseMasterpiece(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * | 5    | Wine ! A chest of wine !                           | -1 Masterpiece                 |
         */
        [Test]
        public void ShouldDecreaseMasterpieceWhenRolls5()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new BriefRedoubt(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(5), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("Wine ! A chest of wine !"));
            sanity.Verify(s => s.IncreaseMasterpiece(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * | 6    | He passed out in his study                         | +1 Masterpiece                 |
         */
        [Test]
        public void ShouldIncreaseMasterpieceWhenRolls6()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new BriefRedoubt(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(6), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He passed out in his study"));
            sanity.Verify(s => s.IncreaseMasterpiece(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }
    }
}