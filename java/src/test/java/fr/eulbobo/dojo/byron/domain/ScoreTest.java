package fr.eulbobo.dojo.byron.domain;

import fr.eulbobo.dojo.byron.domain.builder.ScoreBuilder;
import fr.eulbobo.dojo.byron.domain.builder.ScoreExport;
import org.junit.jupiter.api.Test;

import java.util.Objects;
import java.util.stream.IntStream;

import static org.assertj.core.api.Assertions.assertThat;

class ScoreTest {

    @Test
    void shouldNotReduceStressScoreBelow0() {
        Score score = new Score();
        IntStream.range(0, 5).forEach(i -> score.decreaseStress());
        IntStream.range(0, 10).forEach(i -> score.increaseStress());
        assertThat(score.gameStillOn()).isFalse();

        InnerScoreExport export = new InnerScoreExport();
        score.exportTo(export);
        assertThat(export).isEqualTo(InnerScoreExport.from(0, 10, 0));
    }

    @Test
    void shouldNotReduceMasterpieceScoreBelow0() {
        Score score = new Score();
        IntStream.range(0, 5).forEach(i -> score.decreaseMasterpiece());
        IntStream.range(0, 10).forEach(i -> score.increaseMasterpiece());
        assertThat(score.gameStillOn()).isFalse();

        InnerScoreExport export = new InnerScoreExport();
        score.exportTo(export);
        assertThat(export).isEqualTo(InnerScoreExport.from(0, 0, 10));
    }

    @Test
    void shouldNotBeGameOverUnder9OfScore() {
        Score score = new Score();
        IntStream.range(0, 9).forEach(i -> {
            score.increaseScandal();
            score.increaseStress();
            score.increaseMasterpiece();
        });
        assertThat(score.gameStillOn()).isTrue();

        InnerScoreExport export = new InnerScoreExport();
        score.exportTo(export);
        assertThat(export).isEqualTo(InnerScoreExport.from(9, 9, 9));
    }

    @Test
    void shouldBeGameOverIfScandalReaches10() {
        Score score = new Score();
        IntStream.range(0, 10).forEach(i -> score.increaseScandal());
        assertThat(score.gameStillOn()).isFalse();

        InnerScoreExport export = new InnerScoreExport();
        score.exportTo(export);
        assertThat(export).isEqualTo(InnerScoreExport.from(10, 0, 0));
    }

    @Test
    void shouldBeGameOverIfStressReaches10() {
        Score score = new Score();
        IntStream.range(0, 10).forEach(i -> score.increaseStress());
        assertThat(score.gameStillOn()).isFalse();

        InnerScoreExport export = new InnerScoreExport();
        score.exportTo(export);
        assertThat(export).isEqualTo(InnerScoreExport.from(0, 10, 0));
    }

    @Test
    void shouldBeGameOverIfMasterPieceReaches10() {
        Score score = new Score();
        IntStream.range(0, 10).forEach(i -> score.increaseMasterpiece());
        assertThat(score.gameStillOn()).isFalse();

        InnerScoreExport export = new InnerScoreExport();
        score.exportTo(export);
        assertThat(export).isEqualTo(InnerScoreExport.from(0, 0, 10));
    }

    @Test
    void shouldBuildScoreFromBuilder() {
        ScoreBuilder scoreBuilder = new InnerScoreBuilder(9, 9, 9);
        Score score = Score.from(scoreBuilder);
        assertThat(score.gameStillOn()).isTrue();
        score.increaseStress();
        assertThat(score.gameStillOn()).isFalse();
    }

    @Test
    void shouldExtractScoreToExport() {
        InnerScoreExport export = new InnerScoreExport();
        Score score = new Score();
        score.increaseStress();
        score.increaseStress();
        score.increaseStress();
        score.increaseMasterpiece();
        score.increaseMasterpiece();
        score.increaseScandal();

        score.exportTo(export);
        assertThat(export).isEqualTo(InnerScoreExport.from(1, 3, 2));
    }

    private record InnerScoreBuilder(int stress, int scandal, int masterpiece) implements ScoreBuilder {
    }

    private static class InnerScoreExport implements ScoreExport {
        private int scandal, stress, masterpiece;

        static InnerScoreExport from(int scandal, int stress, int masterpiece) {
            InnerScoreExport export = new InnerScoreExport();
            export.scandal = scandal;
            export.stress = stress;
            export.masterpiece = masterpiece;
            return export;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            InnerScoreExport export = (InnerScoreExport) o;
            return scandal == export.scandal && stress == export.stress && masterpiece == export.masterpiece;
        }

        @Override
        public int hashCode() {
            return Objects.hash(scandal, stress, masterpiece);
        }

        @Override
        public void scandalIs(int scandal) {
            this.scandal = scandal;
        }

        @Override
        public void stressIs(int stress) {
            this.stress = stress;
        }

        @Override
        public void masterpieceIs(int masterpiece) {
            this.masterpiece = masterpiece;
        }
    }
}
