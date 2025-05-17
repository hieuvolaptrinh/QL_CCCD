Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class BaoCaoCongDan
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"

    Private Sub BaoCaoCongDan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadReport()
    End Sub

    Private Sub LoadReport()
        Dim ten As String = txtTen.Text.Trim()
        Dim sql As String = "SELECT * FROM CongDanCCCD"
        If ten <> "" Then sql &= " WHERE HoTen LIKE @Ten"

        Dim conn As New SqlConnection(connStr)
        Dim cmd As New SqlCommand(sql, conn)
        If ten <> "" Then cmd.Parameters.AddWithValue("@Ten", "%" & ten & "%")

        Dim dataTable As New DataTable()

        Try
            conn.Open()
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            dataTable.Load(reader)
            reader.Close()
            conn.Close()

            If dataTable.Rows.Count = 0 Then
                MessageBox.Show("Không tìm thấy công dân phù hợp.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Dim rds As New ReportDataSource("DataSet1", dataTable)
            With ReportViewer1.LocalReport
                .DataSources.Clear()
                .ReportEmbeddedResource = "QuanLyCCCD.ReportDSCCCD.rdlc"
                .DataSources.Add(rds)
            End With

            ReportViewer1.RefreshReport()

        Catch ex As Exception
            MessageBox.Show("Lỗi: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        LoadReport()
    End Sub
End Class
