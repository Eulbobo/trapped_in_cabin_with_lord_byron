using fr.eulbobo.dojo.byron.domain;
using Moq;

namespace fr.eulbobo.dojo.byron.tests
{
    public class ByronRecreationTest
    {
        /**
         * 1    | Is he aware the walls are exceptionnaly thin ?           | +1 Stress                 |
         */
        [Test]
        public void shouldAdd1StressWhenRolls1()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event =new ByronRecreation(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(1), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("Is he aware the walls are exceptionnaly thin ?"));
            sanity.Verify(s => s.IncreaseStress(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 2    | He's made a mess of your desk in the process             | -1 MasterPiece            |
         */
        [Test]
        public void shouldReduce1MasterPieceWhenRolls2()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event =new ByronRecreation(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(2), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He's made a mess of your desk in the process"));
            sanity.Verify(s => s.DecreaseMasterpiece(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 3    | May he borrow your husband? Of course.                   | -1 Stress <br> +1 Scandal |
         */
        [Test]
        public void shouldReduceStressByOneAndIncreaseScandalByOneWhenRolls3()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event =new ByronRecreation(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(3), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("May he borrow your husband? Of course."));
            sanity.Verify(s => s.DecreaseStress(), Times.Once);
            sanity.Verify(s => s.IncreaseScandal(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 4    | His Half-sister is here, and they are *FAR* too intimate | +2 Scandal                |
         */
        [Test]
        public void shouldAdd2ScandalWhenRolls4()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event =new ByronRecreation(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(4), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("His Half-sister is here, and they are FAR too intimate"));
            sanity.Verify(s => s.IncreaseScandal(), Times.Exactly(2));
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 5    | You are weary of listening to the tales of his exploits | +1 Stress                 |
         */
        [Test]
        public void shouldAdd1StressWhenRolls5()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event =new ByronRecreation(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(5), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("You are weary of listening to the tales of his exploits"));
            sanity.Verify(s => s.IncreaseStress(), Times.Once);
            sanity.VerifyNoOtherCalls();
        }

        /**
         * 6    | He Makes and excellent muse on occasion                  | -1 Stress <br> +2 Masterpiece |
         */
        [Test]
        public void shouldDecrease1StressAndIncrease2MasterpieceWhenRolls6()
        {
            var sanity = new Mock<Sanity>();
            var eventLog = new Mock<EventLog>();
            ByronEvent @event = new ByronRecreation(eventLog.Object);
            @event.ApplyDiceTo(DiceRoll.Of(6), sanity.Object);

            eventLog.Verify(evtl => evtl.Log("He makes and excellent muse on occasion"));            
            sanity.Verify(s => s.DecreaseStress(), Times.Once);
            sanity.Verify(s => s.IncreaseMasterpiece(), Times.Exactly(2));
            sanity.VerifyNoOtherCalls();
        }
    }
}