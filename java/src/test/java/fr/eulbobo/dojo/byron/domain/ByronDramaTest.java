package fr.eulbobo.dojo.byron.domain;

import org.junit.jupiter.api.Test;
import org.mockito.Mockito;

import static org.mockito.ArgumentMatchers.eq;
import static org.mockito.Mockito.*;

class ByronDramaTest {

    /**
     * 1    | He needs help reading this fan mail                | +1 Stress  |
     */
    @Test
    void shouldAdd1StressWhenRolls1(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronDrama(eventLog);
        event.applyDiceTo(DiceRoll.of(1), sanity);

        verify(eventLog).log(eq("He needs help reading this fan mail"));
        verify(sanity, times(1)).increaseStress();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 2    | He's brought his pet bear. It is not trained       | +2 Stress  |
     */
    @Test
    void shouldAdd2StressWhenRolls2(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronDrama(eventLog);
        event.applyDiceTo(DiceRoll.of(2), sanity);

        verify(eventLog).log(eq("He's brought his pet bear. It is not trained"));
        verify(sanity, times(2)).increaseStress();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 3    | He wants to read you his poetry                    | +3 Stress  |
     */
    @Test
    void shouldAdd3StressWhenRolls3(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronDrama(eventLog);
        event.applyDiceTo(DiceRoll.of(3), sanity);

        verify(eventLog).log(eq("He wants to read you his poetry"));
        verify(sanity, times(3)).increaseStress();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 4    | He's in the papers. Again. Which means you are too | +1 Scandal |
     */
    @Test
    void shouldAdd1ScandalWhenRolls4(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronDrama(eventLog);
        event.applyDiceTo(DiceRoll.of(4), sanity);

        verify(eventLog).log(eq("He's in the papers. Again. Which means you are too"));
        verify(sanity, times(1)).increaseScandal();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 5    | He broke up with his latest girlfriend/boyfriend   | +2 Scandal |
     */
    @Test
    void shouldAdd2ScandalWhenRolls5(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronDrama(eventLog);
        event.applyDiceTo(DiceRoll.of(5), sanity);

        verify(eventLog).log(eq("He broke up with his latest girlfriend/boyfriend"));
        verify(sanity, times(2)).increaseScandal();
        verifyNoMoreInteractions(sanity);
    }

    /**
     * 6    | He's found a new skull to use as a goblet          | +3 Scandal |
     */
    @Test
    void shouldAdd3ScandalWhenRolls6(){
        Sanity sanity = Mockito.mock(Sanity.class);
        EventLog eventLog = Mockito.mock(EventLog.class);
        ByronEvent event = new ByronDrama(eventLog);
        event.applyDiceTo(DiceRoll.of(6), sanity);

        verify(eventLog).log(eq("He's found a new skull to use as a goblet"));
        verify(sanity, times(3)).increaseScandal();
        verifyNoMoreInteractions(sanity);
    }

}