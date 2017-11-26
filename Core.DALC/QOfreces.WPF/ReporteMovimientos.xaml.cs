using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QOfreces.WPF
{
    /// <summary>
    /// Lógica de interacción para ReporteMovimientos.xaml
    /// </summary>
    public partial class ReporteMovimientos : Window
    {
        public ReporteMovimientos()
        {
            InitializeComponent();
            _reportViewer.Load += ReportViewer_Load;
        }

        private bool _isReportViewerLoaded;

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (!_isReportViewerLoaded)
            {
                Microsoft.Reporting.WinForms.ReportDataSource BDMISOFERTAS = new Microsoft.Reporting.WinForms.ReportDataSource();
                MovimientosPorFecha dataset = new MovimientosPorFecha();

                dataset.BeginInit();

                BDMISOFERTAS.Name = "Movimientos"; //Name of the report dataset in our .RDLC file
                BDMISOFERTAS.Value = dataset.MovimientosDataTable;
                this._reportViewer.LocalReport.DataSources.Add(BDMISOFERTAS);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "QOfreces.WPF.ReportPreferencias.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet

                MovimientosPorFechaTableAdapters.MovimientosDataTableTableAdapter movimientosTableAdapter = new MovimientosPorFechaTableAdapters.MovimientosDataTableTableAdapter();
                movimientosTableAdapter.ClearBeforeFill = true;
                movimientosTableAdapter.Fill(dataset.MovimientosDataTable);

                //AdventureWorks2008R2DataSetTableAdapters.SalesOrderDetailTableAdapter salesOrderDetailTableAdapter = new AdventureWorks2008R2DataSetTableAdapters.SalesOrderDetailTableAdapter();
                //salesOrderDetailTableAdapter.ClearBeforeFill = true;
                //salesOrderDetailTableAdapter.Fill(dataset.SalesOrderDetail);

                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }
    }
}
