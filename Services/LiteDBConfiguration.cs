using LiteDB;

namespace DocCentral.WinForms.Services
{
    /// <summary>
    /// Konfiguration zur LiteDB Datenbank.
    /// </summary>
    public interface ILiteDBConfiguration
    {
        /// <summary>
        /// Gibt die Datenbank zurück, mit der man dann auf die LiteDB
        /// Tabellen und Collections zugreifen kann.
        /// </summary>
        LiteDatabase Database { get; }
    }

    /// <summary>
    /// Implementierung von <see cref="ILiteDBConfiguration"/>.
    /// </summary>
    public class LiteDBConfiguration : ILiteDBConfiguration
    {
        private readonly LiteDatabase _db;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="db">Datenbank</param>
        public LiteDBConfiguration(LiteDatabase db)
        {
            _db = db;
        }

        /// <summary>
        /// Zugriffa auf die Datenbank.
        /// </summary>
        public LiteDatabase Database => _db;
    }
}
