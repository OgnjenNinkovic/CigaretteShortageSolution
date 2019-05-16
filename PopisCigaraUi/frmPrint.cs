using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopisCigaraUi
{
    public partial class frmPrint : Form
    {
        List<Cigi> _list;
        string _date, _ukupno,_finManjak,_finVisak;
        public frmPrint(List<Cigi> dataSource, string date,string ukupno,string finManjak,string finVisak)
        {
            InitializeComponent();
            _list = dataSource;
            _date = date;
            _ukupno = ukupno;
            _finManjak = finManjak;
            _finVisak = finVisak;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            MainWindow mw = new MainWindow();
            CigiBindingSource.DataSource = _list;
            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pDate",_date),
                new Microsoft.Reporting.WinForms.ReportParameter("pManjak",_ukupno),
                new Microsoft.Reporting.WinForms.ReportParameter("pFinVisak",_finVisak),
                new Microsoft.Reporting.WinForms.ReportParameter("pFinManjak",_finManjak),


            };
            this.reportViewer.LocalReport.SetParameters(para);
            this.reportViewer.RefreshReport();
        }
    }
}
