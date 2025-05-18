Public Class FormReportViPham
    Private dsSaiPham As List(Of CongDan_SaiPham)

    Public Sub New(listSaiPham As List(Of CongDan_SaiPham))
        InitializeComponent()
        dsSaiPham = listSaiPham
    End Sub

    Private Sub FormReportViPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Thiết lập nguồn dữ liệu cho report
            Me.ReportViewer1.LocalReport.ReportPath = "ReportSaiPham.rdlc"
            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dsSaiPham))
            Me.ReportViewer1.RefreshReport()
        Catch ex As Exception
            MessageBox.Show("Lỗi khi tải report: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class