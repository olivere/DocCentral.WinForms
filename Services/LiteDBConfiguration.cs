using LiteDB;

namespace DocCentral.WinForms.Services
{
    public class LiteDBConfiguration : ILiteDBConfiguration
    {
        public readonly LiteDatabase _db;

        public LiteDBConfiguration(LiteDatabase db)
        {
            _db = db;
        }

        public LiteDatabase Database => _db;
    }
}
