using LiteDB;

namespace DocCentral.WinForms.Services
{
    public interface ILiteDBConfiguration
    {
        LiteDatabase Database { get; }
    }
}
