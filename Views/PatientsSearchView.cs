using DocCentral.WinForms.Models;
using DocCentral.WinForms.ViewModels;
using System;
using System.Windows.Forms;

namespace DocCentral.WinForms.Views
{
    /// <summary>
    /// Windows Form für die Patientensuche.
    /// </summary>
    public partial class PatientsSearchView : Form
    {
        /// <summary>
        /// Konstruktor.
        /// </summary>
        public PatientsSearchView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ViewModel, die in <see cref="OnLoad"/> initialisiert wird.
        /// </summary>
        public PatientsSearchViewModel ViewModel { get; private set; }

        /// <summary>
        /// Laden des Formulars. Hier wird das <see cref="ViewModel"/>
        /// und die Datenbindung initialisiert.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Initialisieren des ViewModel
            ViewModel = App.Current.GetRequiredService<PatientsSearchViewModel>();

            // Datenbindung initialisieren
            bindingSource.DataSource = ViewModel;
        }

        /// <summary>
        /// Tastatureingaben abfangen, insbesondere die Escape-Taste.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Hinweis: Das funktioniert nur, wenn auch KeyPreview = true ist.
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// Stichworteingaben abfangen, insbesondere die Return-Taste, die die
        /// Suche startet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void KeywordsOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                // Die Suche wird vom ViewModel durchgeführt, nicht vom Form!
                await ViewModel.SearchAsync();
            }
        }

        /// <summary>
        /// Schließen des Formulars.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButtonOnClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Nächste Seite aufrufen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void NextPageOnClick(object sender, EventArgs e)
        {
            // Wieder: Das ViewModel trägt die Verantwortung, nicht das Form!
            await ViewModel.NextPageAsync();
        }

        /// <summary>
        /// Vorherige Seite aufrufen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void PreviousPageOnClick(object sender, EventArgs e)
        {
            // Wir delegieren ans ViewModel, das Form ist dumm!
            await ViewModel.PreviousPageAsync();
        }

        /// <summary>
        /// Doppelklick auf eine Zelle im DataGrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DataGridOnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Da das DataGrid direkt an Instanzen des Typs PatientSearchResult bindet,
            // können wir hier direkt auf die gebundene Instanz zugreifen
            var result = dataGrid.Rows.SharedRow(e.RowIndex).DataBoundItem as PatientSearchResult;

            // Wir öffnen das Bearbeitungsfenster.
            var editView = new PatientEditView(result.Id);
            if (editView.ShowDialog() == DialogResult.OK)
            {
                // Hier müssen wir nun das DataGrid aktualisieren
                await ViewModel.SearchAsync();
            }
        }
    }
}
