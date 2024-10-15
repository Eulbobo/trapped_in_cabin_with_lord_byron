package fr.eulbobo.dojo.byron.domain;

import org.junit.jupiter.api.Test;
import org.mockito.Mockito;

import static org.mockito.Mockito.*;

class DisasterMuseTest {

    @Test
    void shouldGetDisasterMuseAfter3rollsResultingIn6() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        DisasterMuse disasterMuse = new DisasterMuse(sanity, eventLog);
        disasterMuse.diceRollIs(DiceRoll.of(6));
        verifyNoInteractions(sanity, eventLog);
        disasterMuse.diceRollIs(DiceRoll.of(6));
        verifyNoInteractions(sanity, eventLog);
        disasterMuse.diceRollIs(DiceRoll.of(6));
        verify(sanity).disaster();
        verify(eventLog).log("Byron destroys your manuscript either by accident or on purpose, during one of his episodes");
        verifyNoMoreInteractions(sanity);
    }

    @Test
    void shouldNotGetDisasterMuseAfterAFourth6Roll() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        DisasterMuse disasterMuse = new DisasterMuse(sanity, eventLog);
        disasterMuse.diceRollIs(DiceRoll.of(6));
        disasterMuse.diceRollIs(DiceRoll.of(6));
        disasterMuse.diceRollIs(DiceRoll.of(6));
        disasterMuse.diceRollIs(DiceRoll.of(6));
        verify(sanity).disaster();
        verify(eventLog).log("Byron destroys your manuscript either by accident or on purpose, during one of his episodes");
        verifyNoMoreInteractions(sanity, eventLog);
    }
}
