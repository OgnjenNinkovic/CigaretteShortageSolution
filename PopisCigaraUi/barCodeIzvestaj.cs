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
    public partial class barCodeIzvestaj : Form
    {
        List<Cigi> _barList;
        string _ukupno, _date;
        public barCodeIzvestaj(List<Cigi> dataSource, string ukupno, string date)
        {
            InitializeComponent();
            _barList = dataSource;
            _ukupno = ukupno;
            _date = date;
        }

        private void barCodeIzvestaj_Load(object sender, EventArgs e)
        {
            CigiBindingSource.DataSource = _barList;

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pDate",_date),
                new Microsoft.Reporting.WinForms.ReportParameter("pUkupno",_ukupno),
            };
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
