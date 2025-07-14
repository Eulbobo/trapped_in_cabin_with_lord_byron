package fr.eulbobo.dojo.byron.domain;

import org.junit.jupiter.api.Test;
import org.mockito.Mockito;

import static org.mockito.ArgumentMatchers.eq;
import static org.mockito.Mockito.*;

class BriefRedoubtTest {

    /**
     * | 1    | Time alone. Blissful time.                         | +1 Masterpiece                 |
     */
    @Test
    void shouldAdd1MasterPieceWhenRolls1(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new BriefRedoubt(eventLog);
        event.applyDiceTo(DiceRoll.of(1), sanity);

        verify(eventLog).log(eq("Time alone. Blissful time."));
        verify(sanity, times(1)).increaseMasterpiece();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * | 2    | He's busy with a paramour.                         | -1 Stress                      |
     */
    @Test
    void shouldDecrease1StressWhenRolls2(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new BriefRedoubt(eventLog);
        event.applyDiceTo(DiceRoll.of(2), sanity);

        verify(eventLog).log(eq("He's busy with a paramour."));
        verify(sanity, times(1)).decreaseStress();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * | 3    | A walk around the house ! Underwear on our heads ! | +1 Scandal                     |
     */
    @Test
    void shouldIncrease1ScandalWhenRolls3(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new BriefRedoubt(eventLog);
        event.applyDiceTo(DiceRoll.of(3), sanity);

        verify(eventLog).log(eq("A walk around the house ! Underwear on our heads !"));
        verify(sanity, times(1)).increaseScandal();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * | 4    | He has an excellent supply of contraband substance | +1 Scandal <br> +1 Masterpiece |
     */
    @Test
    void shouldIncrease1ScandalAndMasterpieceWhenRolls4(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new BriefRedoubt(eventLog);
        event.applyDiceTo(DiceRoll.of(4), sanity);

        verify(eventLog).log(eq("He has an excellent supply of contraband substance"));
        verify(sanity, times(1)).increaseScandal();
        verify(sanity, times(1)).increaseMasterpiece();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * | 5    | Wine ! A chest of wine !                           | -1 Masterpiece                 |
     */
    @Test
    void shouldDecreaseMasterpieceWhenRolls5(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new BriefRedoubt(eventLog);
        event.applyDiceTo(DiceRoll.of(5), sanity);

        verify(eventLog).log(eq("Wine ! A chest of wine !"));
        verify(sanity, times(1)).decreaseMasterpiece();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * | 6    | He passed out in his study                         | +1 Masterpiece                 |
     */
    @Test
    void shouldIncreaseMasterpieceWhenRolls6(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new BriefRedoubt(eventLog);
        event.applyDiceTo(DiceRoll.of(6), sanity);

        verify(eventLog).log(eq("He passed out in his study"));
        verify(sanity, times(1)).increaseMasterpiece();
        verifyNoMoreInteractions(sanity);
    }
}