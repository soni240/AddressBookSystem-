
namespace UC15_JsonFile
{
    internal class CsvWriter
    {
        private StreamWriter writer;
        private object invariantCulture;

        public CsvWriter(StreamWriter writer, object invariantCulture)
        {
            this.writer = writer;
            this.invariantCulture = invariantCulture;
        }

        internal void WriteRecords(List<AddrBook> list)
        {
            throw new NotImplementedException();
        }
    }
}