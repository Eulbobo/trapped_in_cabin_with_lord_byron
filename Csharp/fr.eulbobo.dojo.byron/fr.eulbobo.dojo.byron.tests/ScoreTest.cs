using fr.eulbobo.dojo.byron.domain;
using fr.eulbobo.dojo.byron.domain.builder;

namespace fr.eulbobo.dojo.byron.tests
{
    public class ScoreTest
    {
        [Test]
        public void ShouldNotReduceStressScoreBelow0()
        {
            Score score = new Score();
            Enumerable.Range(0, 5).ToList().ForEach(i => score.DecreaseStress());
            Enumerable.Range(0, 10).ToList().ForEach(i => score.IncreaseStress());
            Assert.IsFalse(score.GameStillOn());

            InnerScoreExport export = new InnerScoreExport();
            score.ExportTo(export);
            Assert.That(export, Is.EqualTo(InnerScoreExport.From(0, 10, 0)));
        }

        [Test]
        public void ShouldNotReduceMasterpieceScoreBelow0()
        {
            Score score = new Score();
            Enumerable.Range(0, 5).ToList().ForEach(i => score.DecreaseMasterpiece());
            Enumerable.Range(0, 10).ToList().ForEach(i => score.IncreaseMasterpiece());
            Assert.IsFalse(score.GameStillOn());

            InnerScoreExport export = new InnerScoreExport();
            score.ExportTo(export);
            Assert.AreEqual(InnerScoreExport.From(0, 0, 10), export);
        }

        [Test]
        public void ShouldNotBeGameOverUnder9OfScore()
        {
            Score score = new Score();
            Enumerable.Range(0, 9).ToList().ForEach(i =>
            {
                score.IncreaseScandal();
                score.IncreaseStress();
                score.IncreaseMasterpiece();
            });
            Assert.IsTrue(score.GameStillOn());

            InnerScoreExport export = new InnerScoreExport();
            score.ExportTo(export);
            Assert.AreEqual(InnerScoreExport.From(9, 9, 9), export);
        }

        [Test]
        public void ShouldBeGameOverIfScandalReaches10()
        {
            Score score = new Score();
            Enumerable.Range(0, 10).ToList().ForEach(i => score.IncreaseScandal());
            Assert.IsFalse(score.GameStillOn());

            InnerScoreExport export = new InnerScoreExport();
            score.ExportTo(export);
            Assert.AreEqual(InnerScoreExport.From(10, 0, 0), export);
        }

        [Test]
        public void ShouldBeGameOverIfStressReaches10()
        {
            Score score = new Score();
            Enumerable.Range(0, 10).ToList().ForEach(i => score.IncreaseStress());
            Assert.IsFalse(score.GameStillOn());

            InnerScoreExport export = new InnerScoreExport();
            score.ExportTo(export);
            Assert.AreEqual(InnerScoreExport.From(0, 10, 0), export);
        }

        [Test]
        public void ShouldBeGameOverIfMasterPieceReaches10()
        {
            Score score = new Score();
            Enumerable.Range(0, 10).ToList().ForEach(i => score.IncreaseMasterpiece());
            Assert.IsFalse(score.GameStillOn());

            InnerScoreExport export = new InnerScoreExport();
            score.ExportTo(export);
            Assert.AreEqual(InnerScoreExport.From(0, 0, 10), export);
        }

        [Test]
        public void ShouldBuildScoreFromBuilder()
        {
            ScoreBuilder scoreBuilder = new InnerScoreBuilder(9, 9, 9);
            Score score = Score.From(scoreBuilder);
            Assert.IsTrue(score.GameStillOn());
            score.IncreaseStress();
            Assert.IsFalse(score.GameStillOn());
        }

        [Test]
        public void ShouldExtractScoreToExport()
        {
            InnerScoreExport export = new InnerScoreExport();
            Score score = new Score();
            score.IncreaseStress();
            score.IncreaseStress();
            score.IncreaseStress();
            score.IncreaseMasterpiece();
            score.IncreaseMasterpiece();
            score.IncreaseScandal();

            score.ExportTo(export);
            Assert.That(export, Is.EqualTo(InnerScoreExport.From(1, 3, 2)));
        }

        private record InnerScoreBuilder(int Stress, int Scandal, int Masterpiece) : ScoreBuilder
        {
        }

        private class InnerScoreExport : ScoreExport
        {
            private int scandal, stress, masterpiece;

            public static InnerScoreExport From(int scandal, int stress, int masterpiece)
            {
                InnerScoreExport export = new InnerScoreExport();
                export.scandal = scandal;
                export.stress = stress;
                export.masterpiece = masterpiece;
                return export;
            }


            public override bool Equals(Object o)
            {
                if (this == o) return true;
                if (o == null || GetType() != o.GetType()) return false;
                InnerScoreExport export = (InnerScoreExport)o;
                return scandal == export.scandal && stress == export.stress && masterpiece == export.masterpiece;
            }

            public override int GetHashCode()
            {
                return System.HashCode.Combine(scandal, stress, masterpiece);
            }

            public override void ScandalIs(int scandal)
            {
                this.scandal = scandal;
            }

            public override void StressIs(int stress)
            {
                this.stress = stress;
            }


            public override void MasterpieceIs(int masterpiece)
            {
                this.masterpiece = masterpiece;
            }
        }
    }
}
