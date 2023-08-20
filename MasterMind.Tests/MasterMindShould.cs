using NUnit.Framework;

namespace QuadaxMasterMindAssessment.Tests
{
    public class MasterMindShould
    {
        [Test]
        public void ReturnGameWonTrue()
        {
            var sut = new MasterMind("2345");
            sut.StartNewGame();
            sut.PlayInput("2345");
            Assert.That(sut.GameWon, Is.True);
        }

        [Test] public void ReturnGameWonFalse()
        {
            var sut = new MasterMind("2345");
            sut.StartNewGame();
            for (int  i = 0; i < 10; i++)
            {
                sut.PlayInput("5432");
            }            
            Assert.That(sut.GameWon, Is.False);
        }

        [Test] 
        public void StoreSecretCode()
        {
            var sut = new MasterMind("2345");
            Assert.That("2345", Is.EqualTo(sut.SecretCode()));
        }

        [Test]
        [TestCaseSource(typeof(CsvDataForPlayInputTestCases), "GetTestCases", new object[] { "TestData.csv" })]
        public string CalculatePlayInputResult(string SecretCode, string PlayInput)
        {
            var sut = new MasterMind(SecretCode);
            sut.StartNewGame();
            string playResult = sut.PlayInput(PlayInput);
            return playResult;
        }

        [Test]
        [TestCaseSource(typeof(CvsDataSanityCheck), "GetRecs")]
        public string CalculatePlayInputResult_SanityCheck(string SecretCode, string PlayInput)
        {
            var sut = new MasterMind(SecretCode);
            sut.StartNewGame();
            string playResult = sut.PlayInput(PlayInput);
            return playResult;
        }
    }
}
