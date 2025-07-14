package fr.eulbobo.dojo.byron.domain;

import org.junit.jupiter.api.Test;
import org.mockito.Mockito;

import static org.mockito.ArgumentMatchers.eq;
import static org.mockito.Mockito.*;


class ByronRecreationTest {

    /**
     * 1    | Is he aware the walls are exceptionnaly thin ?           | +1 Stress                 |
     */
    @Test
    void shouldAdd1StressWhenRolls1() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronRecreation(eventLog);
        event.applyDiceTo(DiceRoll.of(1), sanity);

        verify(eventLog).log(eq("Is he aware the walls are exceptionnaly thin ?"));
        verify(sanity, times(1)).increaseStress();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 2    | He's made a mess of your desk in the process             | -1 MasterPiece            |
     */
    @Test
    void shouldReduce1MasterPieceWhenRolls2() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronRecreation(eventLog);
        event.applyDiceTo(DiceRoll.of(2), sanity);

        verify(eventLog).log(eq("He's made a mess of your desk in the process"));
        verify(sanity, times(1)).decreaseMasterpiece();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 3    | May he borrow your husband? Of course.                   | -1 Stress <br> +1 Scandal |
     */
    @Test
    void shouldReduceStressByOneAndIncreaseScandalByOneWhenRolls3() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronRecreation(eventLog);
        event.applyDiceTo(DiceRoll.of(3), sanity);

        verify(eventLog).log(eq("May he borrow your husband? Of course."));
        verify(sanity, times(1)).decreaseStress();
        verify(sanity, times(1)).increaseScandal();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 4    | His Half-sister is here, and they are *FAR* too intimate | +2 Scandal                |
     */
    @Test
    void shouldAdd2ScandalWhenRolls4() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronRecreation(eventLog);
        event.applyDiceTo(DiceRoll.of(4), sanity);

        verify(eventLog).log(eq("His Half-sister is here, and they are FAR too intimate"));
        verify(sanity, times(2)).increaseScandal();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 5    | You are weary of listening to the tales of his exploits | +1 Stress                 |
     */
    @Test
    void shouldAdd1StressWhenRolls5() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronRecreation(eventLog);
        event.applyDiceTo(DiceRoll.of(5), sanity);

        verify(eventLog).log(eq("You are weary of listening to the tales of his exploits"));
        verify(sanity, times(1)).increaseStress();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 6    | He Makes and excellent muse on occasion                  | -1 Stress <br> +2 Masterpiece |
     */
    @Test
    void shouldDecrease1StressAndIncrease2MasterpieceWhenRolls6() {
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronRecreation(eventLog);
        event.applyDiceTo(DiceRoll.of(6), sanity);

        verify(eventLog).log(eq("He makes and excellent muse on occasion"));
        verify(sanity, times(1)).decreaseStress();
        verify(sanity, times(2)).increaseMasterpiece();
        verifyNoMoreInteractions(sanity);
    }

}