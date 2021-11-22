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

namespace DocCentral.WinForms
{
    /// <summary>
    /// Das Hauptfenster der Applikation, die sogenannte Shell.
    /// Hier findet keinerlei Logik statt: Alles wird an das ShellViewModel
    /// weitergeleitet. Diese instruiert dann diese ShellView, entsprechend
    /// zu reagieren.
    /// </summary>
    public partial class ShellView : Form
    {
        public ShellView()
        {
            InitializeComponent();
        }

        public ShellViewModel ViewModel { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ViewModel = App.Current.GetRequiredService<ShellViewModel>();
        }

        private void PatientsButtonOnClick(object sender, EventArgs args)
        {
            ViewModel.OpenPatientsSearch(this);
        }
    }
}
