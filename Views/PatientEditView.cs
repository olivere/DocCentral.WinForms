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
    public partial class PatientEditView : Form
    {
        private readonly int _patientId;

        public PatientEditView(int patientId)
        {
            _patientId = patientId;

            InitializeComponent();
        }

        public PatientEditViewModel ViewModel { get; private set; }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ViewModel = App.Current.GetRequiredService<PatientEditViewModel>();

            await ViewModel.LoadAsync(_patientId);

            bindingSource.DataSource = ViewModel;
            bindingSourcePatient.DataSource = ViewModel.Patient;
        }

        private void SaveOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelOnClick(object sender, EventArgs e)
        {

        }

        private void DeleteOnClick(object sender, EventArgs e)
        {

        }
    }
}
