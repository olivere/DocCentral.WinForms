
namespace DocCentral.WinForms.Views
{
    partial class PatientsSearchView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtBlankslate = new System.Windows.Forms.TextBox();
            this.lblPagination = new System.Windows.Forms.Label();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.displayNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateOfBirthFormattedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suchbegriff:";
            // 
            // txtKeywords
            // 
            this.txtKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKeywords.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Keywords", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtKeywords.Location = new System.Drawing.Point(83, 10);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(529, 20);
            this.txtKeywords.TabIndex = 1;
            this.txtKeywords.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeywordsOnKeyDown);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.AutoGenerateColumns = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.displayNameDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.dateOfBirthFormattedDataGridViewTextBoxColumn});
            this.dataGrid.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "NotBlankslate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dataGrid.DataMember = "Results";
            this.dataGrid.DataSource = this.bindingSource;
            this.dataGrid.Location = new System.Drawing.Point(16, 36);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.Size = new System.Drawing.Size(596, 364);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridOnCellDoubleClick);
            this.dataGrid.SelectionChanged += new System.EventHandler(this.DataGridOnSelectionChanged);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(537, 406);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Schließen";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.CloseButtonOnClick);
            // 
            // txtBlankslate
            // 
            this.txtBlankslate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlankslate.BackColor = System.Drawing.SystemColors.Control;
            this.txtBlankslate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlankslate.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.bindingSource, "Blankslate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtBlankslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBlankslate.Location = new System.Drawing.Point(83, 196);
            this.txtBlankslate.Multiline = true;
            this.txtBlankslate.Name = "txtBlankslate";
            this.txtBlankslate.Size = new System.Drawing.Size(468, 30);
            this.txtBlankslate.TabIndex = 4;
            this.txtBlankslate.Text = "Geben Sie einen Suchbegriff ein und klicken Return.";
            this.txtBlankslate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPagination
            // 
            this.lblPagination.AutoSize = true;
            this.lblPagination.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "Paginator", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lblPagination.Location = new System.Drawing.Point(58, 411);
            this.lblPagination.Name = "lblPagination";
            this.lblPagination.Size = new System.Drawing.Size(70, 13);
            this.lblPagination.TabIndex = 5;
            this.lblPagination.Text = "1-20 von 206";
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSource, "HasPreviousPage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnPrevPage.Location = new System.Drawing.Point(16, 406);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(35, 23);
            this.btnPrevPage.TabIndex = 6;
            this.btnPrevPage.Text = "<< Zurück";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.PreviousPageOnClick);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bindingSource, "HasNextPage", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.btnNextPage.Location = new System.Drawing.Point(134, 406);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(35, 23);
            this.btnNextPage.TabIndex = 7;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.NextPageOnClick);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(DocCentral.WinForms.ViewModels.PatientsSearchViewModel);
            // 
            // displayNameDataGridViewTextBoxColumn
            // 
            this.displayNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            this.displayNameDataGridViewTextBoxColumn.Frozen = true;
            this.displayNameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.displayNameDataGridViewTextBoxColumn.MinimumWidth = 180;
            this.displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            this.displayNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.displayNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateOfBirthFormattedDataGridViewTextBoxColumn
            // 
            this.dateOfBirthFormattedDataGridViewTextBoxColumn.DataPropertyName = "DateOfBirthFormatted";
            this.dateOfBirthFormattedDataGridViewTextBoxColumn.HeaderText = "Geburtsdatum";
            this.dateOfBirthFormattedDataGridViewTextBoxColumn.Name = "dateOfBirthFormattedDataGridViewTextBoxColumn";
            this.dateOfBirthFormattedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateOfBirthFormattedDataGridViewTextBoxColumn.Width = 98;
            // 
            // PatientsSearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.lblPagination);
            this.Controls.Add(this.txtBlankslate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "PatientsSearchView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Patientensuche";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtBlankslate;
        private System.Windows.Forms.Label lblPagination;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateOfBirthFormattedDataGridViewTextBoxColumn;
    }
}