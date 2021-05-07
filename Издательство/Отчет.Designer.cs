namespace Издательство
{
    partial class Отчет
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
            this.АвторыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ИздательствоData = new Издательство.ИздательствоData();
            this.АвторыTableAdapter = new Издательство.ИздательствоDataTableAdapters.АвторыTableAdapter();
            this.издательствоData1 = new Издательство.ИздательствоData();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.АвторыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ИздательствоData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.издательствоData1)).BeginInit();
            this.SuspendLayout();
            // 
            // АвторыBindingSource
            // 
            this.АвторыBindingSource.DataMember = "Авторы";
            this.АвторыBindingSource.DataSource = this.ИздательствоData;
            // 
            // ИздательствоData
            // 
            this.ИздательствоData.DataSetName = "ИздательствоData";
            this.ИздательствоData.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // АвторыTableAdapter
            // 
            this.АвторыTableAdapter.ClearBeforeFill = true;
            // 
            // издательствоData1
            // 
            this.издательствоData1.DataSetName = "ИздательствоData";
            this.издательствоData1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Издательство.Авторы.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Отчет
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Отчет";
            this.Text = "Отчет";
            this.Load += new System.EventHandler(this.Отчет_Load);
            ((System.ComponentModel.ISupportInitialize)(this.АвторыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ИздательствоData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.издательствоData1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource АвторыBindingSource;
        private ИздательствоData ИздательствоData;
        private ИздательствоDataTableAdapters.АвторыTableAdapter АвторыTableAdapter;
        private ИздательствоData издательствоData1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}