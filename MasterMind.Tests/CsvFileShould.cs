using NUnit.Framework;
using Utils;

namespace QuadaxMasterMindAssessment.Tests
{
    public class CsvFileShould
    {
        [Test]
        public void ProcessCsvFile()
        {
            CsvFileProcessor csvFileProcessor = new CsvFileProcessor("TestData.csv");
            var testCases = new List<TestCaseData>();

            if (csvFileProcessor.ProcessFile())
            {
                if (csvFileProcessor.HasRecords)
                {
                    var records = csvFileProcessor.Records;
                    if (records != null)
                    {
                        foreach (var rec in records)
                        {
                            testCases.Add(new TestCaseData(rec.SecretCode, rec.PlayInput).Returns(rec.ExpectedResult));
                        }
                    }
                }
            }

            Assert.That(testCases.Count, Is.GreaterThan(0));
        }
    }
}
