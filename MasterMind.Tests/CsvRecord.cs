namespace QuadaxMasterMindAssessment.Tests
{
    public class CsvRecord
    {
        public string? SecretCode { get; set; }
        public string? PlayInput { get; set; }
        public string? ExpectedResult { get; set; }

        public CsvRecord() { }
        public CsvRecord(string secretCode, string playInput, string expectedResult)
        {
            SecretCode = secretCode;
            PlayInput = playInput;
            ExpectedResult = expectedResult;
        }

    }
}
