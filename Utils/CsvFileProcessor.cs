using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics;
using System.Globalization;

namespace Utils
{
    public class CsvFileProcessor
    {
        public string  InputFilePath { get; private set; }
        public bool FileWasProcessed { get; private set; }
        public bool HasRecords { get; private set; }
        public IEnumerable<dynamic>? Records { get; private set; }
        public CsvFileProcessor(string inputFilePath)
        {
            InputFilePath = inputFilePath;
            FileWasProcessed = false;
            HasRecords = false;
        }

        public bool ProcessFile()
        {
            if (!File.Exists(InputFilePath))
            {
                return false;
            }
            try
            {
                using StreamReader inputReader = File.OpenText(InputFilePath);

                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);

                // https://joshclose.github.io/CsvHelper/getting-started/
                // "CsvReader is forward only, so if you want to run any LINQ queries against your data,
                // you'll have to pull the whole file into memory. Just know that is what you're doing."
                using CsvReader csvReader = new CsvReader(inputReader, csvConfiguration);

                Records = csvReader.GetRecords<dynamic>().ToList();

                FileWasProcessed = true;

                if (Records != null)
                {
                    if (Records.Any())
                    {
                        HasRecords = true;
#if DEBUG
                        foreach (var record in Records)
                        {
                            var type = record.GetType();
                            Debug.WriteLine($"record type is: {type}");

                            foreach (var property in (IDictionary<String, Object>)record)
                            {
                                Debug.WriteLine(property.Key + ": " + property.Value);
                            }
                        }
#endif
                    }                    
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}