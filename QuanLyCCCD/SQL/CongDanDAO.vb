Imports System.Data.SqlClient

Public Class CongDanDAO
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(connStr)
    End Sub

    ' Lấy tất cả thông tin công dân từ bảng CongDanCCCD
    Public Function LayTatCaCongDan() As DataTable
        Dim dataTable As New DataTable()
        Try
            conn.Open()
            Dim query As String = "SELECT * FROM CongDanCCCD"
            Using cmd As New SqlCommand(query, conn)
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dataTable)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Lỗi khi lấy dữ liệu công dân: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        Return dataTable
    End Function
End Class