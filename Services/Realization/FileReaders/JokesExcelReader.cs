using ExcelDataReader;
using R00ster.Entities;
using R00ster.Services.Interfaces.FileReaders;
using System.IO;


namespace R00ster.Services.Realization.FileReaders
{
    internal class JokesExcelReader : IJokesExcelReader
    {
        public async IAsyncEnumerable<Joke> ReadAsync(string pathToFile)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(pathToFile, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        var value = reader.GetString(0);
                        var newObject = new Joke();
                        newObject.Text = value;
                        yield return newObject;
                    }
                }
            }
        }
    }
}
