package fr.eulbobo.dojo.byron.domain;

import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.IntStream;
import java.util.stream.Stream;

import static org.assertj.core.api.Assertions.assertThat;

class TrappedInACabinWithByronTest {

    @ParameterizedTest(name = "{index} {0}")
    @MethodSource("rollsAndResults")
    void dontStayTrappedInACabinWithLordByron(String name, List<Integer> rolls, List<String> expectedLines, boolean gameOn) {
        List<String> logs = new ArrayList<>();
        Score sanity = new Score();
        TrappedInACabinWithLordByron trappedInACabinWithByron = new TrappedInACabinWithLordByron(sanity, logs::add);

        rolls.stream().map(DiceRoll::of).forEach(trappedInACabinWithByron::diceRollIs);

        assertThat(logs).containsExactlyElementsOf(expectedLines);
        assertThat(sanity.gameStillOn()).isEqualTo(gameOn);
    }

    static Stream<Arguments> rollsAndResults() {
        return Stream.of(someRollsWillLeadToTheSameEffect(), multipleByronEventsEffects(), multipleByronEvents(), avoidDisasterMuse(), disasterMuseCanHappenAnytime(), masterpieceEnding());
    }

    static Arguments someRollsWillLeadToTheSameEffect() {
        List<Integer> rolls = List.of(3, 2, 4, 2);

        List<String> lines = new ArrayList<>();
        lines.add("He's brought his pet bear. It is not trained");
        lines.add("He's brought his pet bear. It is not trained");

        return Arguments.of("Different rolls, same effect", rolls, lines, true);
    }


    static Arguments multipleByronEventsEffects() {
        List<Integer> rolls = List.of(1, 2, 1, 1);

        List<String> lines = new ArrayList<>();
        lines.add("He's made a mess of your desk in the process");
        lines.add("Is he aware the walls are exceptionnaly thin ?");

        return Arguments.of("Different Byron Events effects", rolls, lines, true);
    }

    static Arguments multipleByronEvents() {
        List<Integer> rolls = List.of(1, 2, 3, 4);

        List<String> lines = new ArrayList<>();
        lines.add("He's made a mess of your desk in the process");
        lines.add("He's in the papers. Again. Which means you are too");

        return Arguments.of("Different Byron Events", rolls, lines, true);
    }

    static Arguments avoidDisasterMuse() {
        List<Integer> rolls = List.of(1, 2, 6, 6, 6, 1);

        List<String> lines = new ArrayList<>();
        lines.add("He's made a mess of your desk in the process");
        lines.add("He passed out in his study");
        lines.add("Byron destroys your manuscript either by accident or on purpose, during one of his episodes");
        lines.add("Time alone. Blissful time.");

        return Arguments.of("Avoid Disaster Muse", rolls, lines, true);
    }

    static Arguments disasterMuseCanHappenAnytime() {
        List<Integer> rolls = List.of(1, 6, 6, 6);

        List<String> lines = new ArrayList<>();
        lines.add("He makes and excellent muse on occasion");
        lines.add("Byron destroys your manuscript either by accident or on purpose, during one of his episodes");
        lines.add("He passed out in his study");

        return Arguments.of("Disaster Muse happens anytime", rolls, lines, true);
    }

    static Arguments masterpieceEnding() {
        List<Integer> rolls = new ArrayList<>();
        IntStream.range(0, 5).forEach(i -> {
            rolls.add(1);
            rolls.add(6); // -1 stress +2 masterpiece
        });
        // game should be over now
        rolls.add(1);
        rolls.add(1);

        List<String> lines = new ArrayList<>();
        IntStream.range(0, 5).forEach(i -> lines.add("He makes and excellent muse on occasion"));
        lines.add("You create a new genre or supernatural horror fiction based on your time with Byron");
        lines.add("Game is over");
        lines.add("Game is over");
        return Arguments.of("Game over after masterpiece is done", rolls, lines, false);
    }
}
