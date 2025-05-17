Imports Microsoft.Reporting.WinForms

Public Class BaoCaoNguoiDung_ViPham
    Private Sub BaoCaoNguoiDung_ViPham_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rds As New ReportDataSource("DataSet1", CongDan_SaiPham.GetAllCongDan_SP)
        Me.ReportViewer1.LocalReport.ReportPath = "ReportTest.rdlc"

        Me.ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(rds)
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class