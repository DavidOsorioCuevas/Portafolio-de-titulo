﻿using System;
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
    /// Lógica de interacción para ReportValoraciones.xaml
    /// </summary>
    public partial class ReportValoraciones : Window
    {
        public ReportValoraciones()
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
                ValoracionesDataSet dataset = new ValoracionesDataSet();

                dataset.BeginInit();

                BDMISOFERTAS.Name = "Valoraciones"; //Name of the report dataset in our .RDLC file
                BDMISOFERTAS.Value = dataset.Valoraciones;
                this._reportViewer.LocalReport.DataSources.Add(BDMISOFERTAS);
                this._reportViewer.LocalReport.ReportEmbeddedResource = "QOfreces.WPF.Reporte Valoraciones.rdlc";

                dataset.EndInit();

                //fill data into adventureWorksDataSet
                ValoracionesDataSetTableAdapters.ValoracionesTableAdapter valoracionesTableAdapter = new ValoracionesDataSetTableAdapters.ValoracionesTableAdapter();
                valoracionesTableAdapter.ClearBeforeFill = true;
                valoracionesTableAdapter.Fill(dataset.Valoraciones);

                _reportViewer.RefreshReport();

                _isReportViewerLoaded = true;
            }
        }
    }
}