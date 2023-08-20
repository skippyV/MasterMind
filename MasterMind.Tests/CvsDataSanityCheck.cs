using NUnit.Framework;
using System.Collections;

namespace QuadaxMasterMindAssessment.Tests
{
    public class CvsDataSanityCheck
    {
        public static IEnumerable GetRecs()
        {
            List<CsvRecord> recs = new List<CsvRecord> 
            { 
                new CsvRecord { SecretCode = "2345", PlayInput = "2354", ExpectedResult = "++--" },
                new CsvRecord { SecretCode = "2345", PlayInput = "2534", ExpectedResult = "+---" }
            };

            var testCases = new List<TestCaseData>();

            foreach (var rec in recs)
            {
                testCases.Add(new TestCaseData(rec.SecretCode, rec.PlayInput).Returns(rec.ExpectedResult));
            }

            return testCases;
        }
    }
}
