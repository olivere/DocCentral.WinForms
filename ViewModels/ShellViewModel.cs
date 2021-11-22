using Microsoft.Extensions.Logging;
using System.Windows.Forms;
using DocCentral.WinForms.Views;
using DocCentral.WinForms.Models;

namespace DocCentral.WinForms.ViewModels
{
    /// <summary>
    /// Dieses ViewModel steuert die Logik des Hauptfensters der Applikation,
    /// der ShellView. Sie weiß nichts über Buttons, Eingabefelder, Menüs etc.
    /// Sie weiß aber, wie reagiert werden muss, wenn ein Benutzer eine bestimte
    /// Aktion durchführt.
    /// </summary>
    public class ShellViewModel
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="logger"></param>
        public ShellViewModel(ILogger<ShellViewModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Öffnet das Fenster zur Patientensuche.
        /// </summary>
        /// <param name="parent"></param>
        public void OpenPatientsSearch(Form parent)
        {
            var view = new PatientsSearchView();
            view.Show(parent);
        }
    }
}
