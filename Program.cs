using LiteDB;
using System;
using System.IO;
using System.Windows.Forms;

namespace DocCentral.WinForms
{
    /// <summary>
    /// Program ist der Einstiegspunkt in die Anwendung.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Benötigen wir eine In-Memory DB, können wir als dbname auch ":memory:" verwenden.
            // Wir speichern aber die DB im Roadmin-Profile, so dass sie immer wieder vorhanden ist.
            var dbpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dbname = Path.Combine(dbpath, "DocCentral.db");
            using (var db = new LiteDatabase(dbname))
            {
                App.DB = db;

                var shellView = App.Current.GetService<ShellView>();
                Application.Run(shellView);
            }
        }
    }
}
