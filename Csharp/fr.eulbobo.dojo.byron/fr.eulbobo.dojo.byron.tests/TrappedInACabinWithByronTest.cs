using fr.eulbobo.dojo.byron.domain;

namespace fr.eulbobo.dojo.byron.tests
{
    public class TrappedInACabinWithByronTest
    {

        [TestCaseSource(nameof(rollsAndResults))]
        public void dontStayTrappedInACabinWithLordByron(string name, List<int> rolls, List<string> expectedLines, bool gameOn)
        {
            EventLogger logs = new();
            Score sanity = new Score();
            TrappedInACabinWithLordByron trappedInACabinWithByron = new TrappedInACabinWithLordByron(sanity, logs);

            rolls.Select(i => DiceRoll.Of(i)).ToList().ForEach(trappedInACabinWithByron.DiceRollIs);
            
            Assert.That(logs.Lines, Is.EquivalentTo(expectedLines));
            Assert.That(sanity.GameStillOn(), Is.EqualTo(gameOn));
        }

        public static object[] rollsAndResults()
        {
            return [someRollsWillLeadToTheSameEffect(), multipleByronEventsEffects(), multipleByronEvents(), avoidDisasterMuse(), disasterMuseCanHappenAnytime(), masterpieceEnding()];
        }

        static object[] someRollsWillLeadToTheSameEffect()
        {
            List<int> rolls = [3, 2, 4, 2];

            List<string> lines = ["He's brought his pet bear. It is not trained", "He's brought his pet bear. It is not trained"];

            return ["Different rolls, same effect", rolls, lines, true];
        }


        static object[] multipleByronEventsEffects()
        {
            List<int> rolls = [1, 2, 1, 1];

            List<string> lines = ["He's made a mess of your desk in the process", "Is he aware the walls are exceptionnaly thin ?"];

            return ["Different Byron Events effects", rolls, lines, true];
        }

        static object[] multipleByronEvents()
        {
            List<int> rolls = [1, 2, 3, 4];

            List<string> lines = ["He's made a mess of your desk in the process", "He's in the papers. Again. Which means you are too"];

            return ["Different Byron Events", rolls, lines, true];
        }

        static object[] avoidDisasterMuse()
        {
            List<int> rolls = [1, 2, 6, 6, 6, 1];

            List<string> lines =
            [
                "He's made a mess of your desk in the process",
                "He passed out in his study",
                "Byron destroys your manuscript either by accident or on purpose, during one of his episodes",
                "Time alone. Blissful time.",
            ];

            return ["Avoid Disaster Muse", rolls, lines, true];
        }

        static object[] disasterMuseCanHappenAnytime()
        {
            List<int> rolls = [1, 6, 6, 6];

            List<string> lines =
            [
                "He makes and excellent muse on occasion",
                "Byron destroys your manuscript either by accident or on purpose, during one of his episodes",
                "He passed out in his study",
            ];

            return ["Disaster Muse happens anytime", rolls, lines, true];
        }

        static object[] masterpieceEnding()
        {
            List<int> rolls = new();
            Enumerable.Range(0, 5).ToList().ForEach(i =>
            {
                rolls.Add(1);
                rolls.Add(6); // -1 stress +2 masterpiece
            });
            // game should be over now
            rolls.Add(1);
            rolls.Add(1);

            List<string> lines = new();
            Enumerable.Range(0, 5).ToList().ForEach(i => lines.Add("He makes and excellent muse on occasion"));
            lines.Add("You create a new genre or supernatural horror fiction based on your time with Byron");
            lines.Add("Game is over");
            lines.Add("Game is over");
            return ["Game over after masterpiece is done", rolls, lines, false];
        }

        private class EventLogger : EventLog
        {
            private List<string> lines = new();

            public IEnumerable<string> Lines => lines;
            public void Log(string logMessage)
            {
                lines.Add(logMessage);
            }
        }
    }
}
