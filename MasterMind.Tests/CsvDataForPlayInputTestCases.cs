using NUnit.Framework;
using System.Collections;
using Utils;

namespace QuadaxMasterMindAssessment.Tests
{
    public class CsvDataForPlayInputTestCases
    {
        public static IEnumerable GetTestCases(string csvFileName)
        {
            var testCases = new List<TestCaseData>();

            CsvFileProcessor csvFileProcessor = new CsvFileProcessor(csvFileName);

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

            return testCases;
        }
    }
}
