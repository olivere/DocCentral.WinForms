using DocCentral.WinForms.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocCentral.WinForms.Views
{
    /// <summary>
    /// Windows Form für die Anzeige und Bearbeitung eines Patienten.
    /// </summary>
    public partial class PatientEditView : Form
    {
        private readonly int _patientId;

        /// <summary>
        /// Konstruktor des Fensters.
        /// </summary>
        /// <param name="patientId">Zu bearbeitender Patient</param>
        public PatientEditView(int patientId)
        {
            _patientId = patientId;

            InitializeComponent();
        }

        /// <summary>
        /// ViewModel für dieses Form. Wird in <see cref="OnLoad"/> initialisiert.
        /// </summary>
        public PatientEditViewModel ViewModel { get; private set; }

        /// <summary>
        /// Laden des Formulars.
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Initialisieren des ViewModels, so dass wir darauf in allen
            // Event-Handlern zugreifen können.
            ViewModel = App.Current.GetRequiredService<PatientEditViewModel>();

            // Laden des Patienten
            await ViewModel.LoadAsync(_patientId);

            // Datenbindung initialisieren.
            bindingSource.DataSource = ViewModel;
            bindingSourcePatient.DataSource = ViewModel.Patient;
        }

        /// <summary>
        /// Speichern.
        /// 
        /// Wichtig: Der View macht nichts selbst: Er verweist stattdessen auf
        /// eine entsprechende Speichern-Funktion im ViewModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveOnClick(object sender, EventArgs e)
        {
            try
            {
                await ViewModel.UpdateAsync();
                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Das Aktualisieren ist fehlgeschlagen:" +
                    Environment.NewLine +
                    Environment.NewLine +
                    ex.Message,
                    "Fehler",
                    MessageBoxButtons.OK);
            }

        }

        /// <summary>
        /// Abbruch.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelOnClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Löschen.
        /// 
        /// Wichtig: Der View macht nichts selbst: Er verweist stattdessen auf
        /// eine entsprechende Löschen-Funktion im ViewModel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteOnClick(object sender, EventArgs e)
        {
            MessageBox.Show("Löschen ist noch nicht implementiert", "Hinweis", MessageBoxButtons.OK); ;
        }
    }
}
