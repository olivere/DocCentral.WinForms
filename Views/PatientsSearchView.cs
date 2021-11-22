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
    public partial class PatientsSearchView : Form
    {
        public PatientsSearchView()
        {
            InitializeComponent();
        }

        public PatientsSearchViewModel ViewModel { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ViewModel = App.Current.GetRequiredService<PatientsSearchViewModel>();
            bindingSource.DataSource = ViewModel;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Das funktioniert nur, wenn auch KeyPreview = true ist.
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private async void KeywordsOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                await ViewModel.SearchAsync();
            }
        }

        private void CloseButtonOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private async void NextPageOnClick(object sender, EventArgs e)
        {
            await ViewModel.NextPageAsync();
        }

        private async void PreviousPageOnClick(object sender, EventArgs e)
        {
            await ViewModel.PreviousPageAsync();
        }

        private void DataGridOnCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var result = dataGrid.Rows.SharedRow(e.RowIndex).DataBoundItem as PatientsSearchViewModel.SearchResult;
            var editView = new PatientEditView(result.Id);
            if (editView.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void DataGridOnSelectionChanged(object sender, EventArgs e)
        {
        }
    }
}
