
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Издательство
{
    public partial class Отчет : Form
    {
        public Отчет()
        {
            InitializeComponent();
        }
        string sSql = string.Empty;

        private void Отчет_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "ИздательствоData.Авторы". При необходимости она может быть перемещена или удалена.
            this.АвторыTableAdapter.Fill(this.ИздательствоData.Авторы);

            this.reportViewer1.RefreshReport();
            vLoadData();
            this.reportViewer1.RefreshReport();
        }

        private void vLoadData()
        {
            reportViewer1.LocalReport.DataSources.Clear();
            DataSet MyDataSet = new DataSet();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            string sBank = @"D:\\Павел\\Учеба\\П - 41\\БД и СУБД\\КП Кобяк\\Издательство.accdb";
            using (OleDbConnection oleConn = new OleDbConnection(connectionString + sBank))
            {
                try
                {
                    oleConn.Open();
                    OleDbCommand olecmd = new OleDbCommand(sSql, oleConn);
                    olecmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(olecmd);
                    da.Fill(MyDataSet);
                }
                catch (Exception/* ex*/)
                {
                    return;
                }
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportEmbeddedResource = "Издательство.Report1.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ИздательствоData1_Авторы", MyDataSet.Tables["Авторы"]));
            this.reportViewer1.RefreshReport();
        }
    }
}
