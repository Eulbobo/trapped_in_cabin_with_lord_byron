package fr.eulbobo.dojo.byron.domain;

import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.Arguments;
import org.junit.jupiter.params.provider.MethodSource;

import java.util.stream.Stream;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.Mockito.mock;

class ByronEventFactoryTest {

    static Stream<Arguments> byronEvents() {
        return Stream.of(Arguments.of(1, ByronRecreation.class),
                Arguments.of(2, ByronRecreation.class),
                Arguments.of(3, ByronDrama.class),
                Arguments.of(4, ByronDrama.class),
                Arguments.of(5, BriefRedoubt.class),
                Arguments.of(6, BriefRedoubt.class));
    }

    @ParameterizedTest
    @MethodSource("byronEvents")
    void shouldGetCorrectByronEventOnDiceRoll(int roll, Class expectedInterface) {
        ByronEventFactory factory = new ByronEventFactory(mock(EventLog.class));
        assertThat(factory.from(DiceRoll.of(roll))).isExactlyInstanceOf(expectedInterface);
    }
}