Imports System.Data.SqlClient

Public Class CongDanDAO
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"
    Private conn As SqlConnection

    Public Sub New()
        conn = New SqlConnection(connStr)
    End Sub

    ' Lấy tất cả thông tin công dân từ bảng CongDanCCCD

End Class