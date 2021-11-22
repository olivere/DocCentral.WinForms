using System;
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

            var shellView = App.Current.GetService<ShellView>();
            Application.Run(shellView);
        }
    }
}
