Imports System.Data.SqlClient
Imports System.Windows.Forms

Module databaseConnection
    Private connStr As String = "Data Source=HIEUVO;Initial Catalog=QuanLyCCCD;Persist Security Info=True;User ID=sa;Password=sa;TrustServerCertificate=True"

    ' Hàm trả về SqlConnection
    Public Function ConnectDatabase() As SqlConnection
        Return New SqlConnection(connStr)
    End Function

    ' Hàm thực thi SQL trả về SqlDataReader
    Public Function ExecuteSQL(sql As String) As SqlDataReader
        Dim conn As SqlConnection = ConnectDatabase()
        Try
            conn.Open()
            Dim cmd As New SqlCommand(sql, conn)
            Return cmd.ExecuteReader(CommandBehavior.CloseConnection)
        Catch ex As Exception
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            MessageBox.Show("Lỗi khi thực thi câu lệnh SQL: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
End Module
